using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.CompilerServices;

namespace simplex
{
    public partial class Form1 : Form
    {
        int restrictions = 0;
        int variables = 0;
        double[][] equationValues;
        string[] equationSignes;
        double[] equationRezults;
        double[] objectiveValues;
        int maximize;
        int minimize;

        public class Pair<T1, T2> //used for pivot location
        {
            public T1 First { get; set; } //pivot line
            public T2 Second { get; set; } //pivot column
        }

        int rightStringInt(string a, int zero)
        {
            int aux = 1;
            int i = 0;
            
            while (i < a.Length && aux == 1)
            {
                if (i > 0)
                    zero = 0;
                if ((int)a[i] >= 48 + zero && (int)a[i] <= 57)
                {
                    i++;
                }
                else
                {
                    aux = 0;
                }
            }

            return aux;
        }

        int rightCharInt(char a, int zero)
        {
            int aux;

            if ((int)a >= 48 + zero && (int)a <= 57)
            {
                aux = 1;
            }
            else
            {
                aux = 0;
            }

            return aux;
        }

        int rightSign(string a)
        {
            if (a == ">=" || a == "=" || a == "<=")
                return 1;
            else
                return 0;
        }

        int rightDouble(string a)
        {
            int aux = 1;
            int i = 0;

            int point = 0;
            int point_i = 0;
            int point_err = 0;

            int sign = 0;
            int sign_i = 0;
            int sign_err = 0;

            if (a.Length == 1)
                return rightCharInt(a[i], 0);

            while (i < a.Length)
            {
                if (a[i] == '.')
                {
                    point++;
                    point_i = i;
                }

                if (a[i] == '+' || a[i] == '-')
                {
                    sign++;
                    sign_i = i;
                }
                i++;
            }

            if (point > 1)
                point_err = 1;
            else
            if (point == 1 && (point_i == 0 || point_i == a.Length - 1 || (sign == 1 && sign_i == 0 && point_i == 1)))
                point_err = 1;

            if (sign > 1)
                sign_err = 1;
            else
            if (sign == 1 && sign_i != 0)
                sign_err = 1;

            if (sign_err == 1 || point_err == 1)
                aux = 0;
            else
            {
                i = 0;
                if (sign == 0 && point == 0)
                    for (i = 0; i < a.Length && aux == 1; i++)
                    {
                        if (i != 0)
                            aux = rightCharInt(a[i], 0);
                        else
                            aux = rightCharInt(a[i], 1);
                    }
                else
                if (sign == 1 && point == 0)
                    for (i = 1; i < a.Length && aux == 1; i++)
                    {
                        if (i != 1)
                            aux = rightCharInt(a[i], 0);
                        else
                            aux = rightCharInt(a[i], 1);
                    }
                else
                if (sign == 0 && point == 1)
                {
                    if (a[1] == '.' && rightCharInt(a[0], 0) == 0)
                        aux = 0;

                    for (i = 0; i < a.Length && aux == 1; i++)
                    {
                        if (a[i] != '.')
                        {
                            aux = rightCharInt(a[i], 0);
                        }
                    }
                }
                else
                if (sign == 1 && point == 1)
                {
                    if (a[2] == '.' && rightCharInt(a[1], 0) == 0)
                        aux = 0;
                    for (i = 1; i < a.Length && aux == 1; i++)
                    {
                        if (a[i] != '.')
                        {
                            aux = rightCharInt(a[i], 0);
                        }
                    }
                }

            }


            return aux;
        }

        public class Simplex
        {
            public int nrRestrictions;
            private int nrVariables;
            private List<double> c = new List<double>(); //coefficients of the objective function
            public List<int> basis = new List<int>(); //the indexes of the variables which are in the base
            public List<List<double>> simplexTableau = new List<List<double>>(); //coefficients of the restrictions
            private List<String> sign = new List<string>();
            private List<double> freeTerms = new List<double>();
            private List<int> auxiliaryVariables = new List<int>();
            private Pair<int, int> pivot = new Pair<int, int>(); //first element - pivot column, second element - pivot line
            public int err = 0;
            /* The structure of the simplex tableau:
             * simplexTableau[x][0] - the values of the basic variables
             * simplexTableau[lastLine][0] - the value of the objective function in the current base
             * simplexTableau[lastLine][1...lastColumn] - continuing indicators
             */

            public Simplex(int nrVariables, int nrRestrictions,
                           string[] equationSigns,
                           double[] objectiveValues,
                           double[] equationRezults,
                           double[][] equationValues,
                           int parameter = 1)

            {
                this.nrVariables = nrVariables;
                this.nrRestrictions = nrRestrictions;

                c.Add(0);
                for (int i = 0; i < this.nrVariables; i++)
                {
                    double coeff = parameter * objectiveValues[i];
                    c.Add(coeff);
                }

                for (int i = 0; i < this.nrRestrictions; i++)
                {
                    List<double> sublist = new List<double>();

                    for (int j = 0; j < this.nrVariables; j++)
                    {
                        double coeff = equationValues[i][j];
                        sublist.Add(coeff);
                    }

                    simplexTableau.Add(sublist);
                    Console.WriteLine();
                }

                List<double> continuingIdentifiers = new List<double>();
                continuingIdentifiers.Add(0);
                simplexTableau.Add(continuingIdentifiers);
                for (int i = 0; i < this.nrVariables; i++)
                {
                    simplexTableau[nrRestrictions].Add(0); //adding the continuing identifiers
                }

                for (int i = 0; i < this.nrRestrictions; i++)
                {
                    String s = equationSigns[i];
                    sign.Add(s);
                }

                for (int i = 0; i < this.nrRestrictions; i++)
                {
                    double b = equationRezults[i];
                    freeTerms.Add(b);
                }

                for (int i = 0; i < this.nrRestrictions; i++) //adding the values of the base variables in simplex tableau
                {
                    simplexTableau[i].Insert(0, freeTerms[i]);
                }
            }

            private void ConvertToStandardForm()
            {
                for (int i = 0; i < this.nrRestrictions; i++)
                {
                    if (sign[i] == "<=") //adding a slack variable in restriction i
                    {
                        c.Add(0);
                        simplexTableau[i].Add(1); //adding the slack variable
                        simplexTableau[nrRestrictions].Add(0); //adding the continuing identifier for this variable
                        for (int j = 0; j < this.nrRestrictions; j++)
                        {
                            if (i != j)
                            {
                                simplexTableau[j].Add(0); //in the rest of restriction slack variable is 0
                            }
                        }

                        sign[i] = "=";
                    }

                    if (sign[i] == ">=") //subtracting a slack variable in restriction i
                    {
                        c.Add(0);
                        simplexTableau[i].Add(-1); //subtracting the slack variable
                        simplexTableau[nrRestrictions].Add(0); //adding the continuing identifier for this variable
                        for (int j = 0; j < this.nrRestrictions; j++)
                        {
                            if (i != j)
                            {
                                simplexTableau[j].Add(0); //in the rest of restriction slack variable is 0
                            }
                        }

                        sign[i] = "=";
                    }
                }
            }

            private void FirstPhaseInitialBasis()
            {
                bool[] isolated = new bool[this.nrRestrictions]; //the restrictions have isolated variables

                //the coefficients of the isolated variables in the restrictions
                double[] isolated_coeff = new double[this.nrRestrictions];


                for (int i = 0; i < this.nrRestrictions; i++) //find the isolated variables
                {
                    for (int j = 1; j < simplexTableau[i].Count; j++)
                    {
                        bool flag = true;
                        if (simplexTableau[i][j] > 0)
                        {
                            for (int k = 0; k < this.nrRestrictions; k++)
                            {
                                if (simplexTableau[k][j] != 0 && k != i)
                                {
                                    flag = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            flag = false;
                        }

                        if (flag != true) continue;
                        isolated[i] = true;
                        basis.Add(j);
                        isolated_coeff[i] = simplexTableau[i][j];
                    }

                    //if the variable is isolated, we will transform it into 1 by dividing all the restriction by isolated variable
                    if (isolated[i] == true && isolated_coeff[i] != 1)
                    {
                        for (int j = 1; j < simplexTableau[i].Count; j++)
                        {
                            simplexTableau[i][j] /= isolated_coeff[i];
                        }

                        freeTerms[i] /= isolated_coeff[i];
                    }

                    //In the restrictions without isolated variables we will add auxiliary variables
                    if (isolated[i] == false)
                    {
                        simplexTableau[i].Add(1);
                        c.Add(0);
                        auxiliaryVariables.Add(simplexTableau[i].Count -
                                               1); //adding the index in the auxiliary variables list
                        basis.Add(simplexTableau[i].Count - 1); //adding the auxiliary variable into basis
                        simplexTableau[nrRestrictions].Add(0); //adding the continuing identifier for this variable
                        for (int j = 0; j < this.nrRestrictions; j++)
                        {
                            if (i != j)
                            {
                                simplexTableau[j].Add(0);
                            }
                        }
                    }
                }
            }

            private void FirstPhase()
            {
                for (int i = 0; i < this.nrRestrictions; i++) //making all free terms >=0
                {
                    if (freeTerms[i] < 0)
                    {
                        for (int j = 0; j < simplexTableau[i].Count; j++) //multiply all A[i] coefficients by (-1)
                        {
                            simplexTableau[i][j] *= (-1);
                        }

                        freeTerms[i] *= (-1);
                    }
                }

                FirstPhaseInitialBasis();

                //If there are no auxiliary variables in the basis vector, go to phase II
                bool auxiaryVariablesInBase = false;
                for (int i = 0; i < basis.Count; i++)
                {
                    for (int j = 0; j < auxiliaryVariables.Count; j++)
                    {
                        if (basis[i] == auxiliaryVariables[j])
                            auxiaryVariablesInBase = true;
                    }
                }

                if (auxiaryVariablesInBase == false)
                    return;

                SimplexTableauProcessing(1);

                if (Convert.ToDouble(Math.Abs(simplexTableau[nrRestrictions][0])) > 1e-7)
                {
                    err = 1;
                    return;
                }

                //Trying to remove the remaining variables in the base
                for (int i = 0; i < basis.Count; i++)
                {
                    bool flag = false;
                    if (auxiliaryVariables.Contains(basis[i]))
                    {
                        for (int j = 1; j < simplexTableau[nrRestrictions].Count; j++)
                        {
                            if (!auxiliaryVariables.Contains(j) && simplexTableau[i][j] != 0)
                            {
                                flag = true;
                            }
                        }
                        if (flag == false)
                        {
                            for (int k = 0; k <= nrRestrictions; k++)
                            {
                                simplexTableau[k].RemoveAt(basis[i]);
                            }
                            simplexTableau.RemoveAt(i);
                            auxiliaryVariables.Remove(basis[i]);
                            c.Remove(basis[i]);
                            basis.RemoveAt(i);
                            nrRestrictions--;
                        }
                    }
                }

                if (auxiliaryVariables.Count != 0)
                {
                    err = 2; //if there are auxiliary variables in base, prin error
                    return;
                }
            }

            private bool IsOptimal()
            {
                for (int i = 1; i < simplexTableau[nrRestrictions].Count; i++)
                {
                    if (simplexTableau[nrRestrictions][i] > 1e-7)
                    {
                        return false;
                    }
                }

                return true;
            }

            private bool IsUnbounded()
            {
                for (int i = 1; i < simplexTableau[nrRestrictions].Count; i++)
                {
                    bool flag = true;
                    if (simplexTableau[nrRestrictions][i] > 1e-7)
                    {
                        for (int j = 0; j < nrRestrictions; j++)
                        {
                            if (simplexTableau[j][i] > 1e-7)
                            {
                                flag = false;
                                break;
                            }
                        }
                    }

                    if (!flag) return false;
                }

                return true;
            }

            private bool FindPivot(int phase)
            {
                //Determining the column of the pivot
                double max = Double.MinValue;
                int maxIndex = 0;
                for (int i = 1; i < simplexTableau[nrRestrictions].Count; i++)
                {
                    if (simplexTableau[nrRestrictions][i] > max)
                    {
                        max = simplexTableau[nrRestrictions][i];
                        maxIndex = i;
                    }
                }

                pivot.Second = maxIndex;

                //Determining the line of the pivot
                //comment the code
                double min = Double.MaxValue;
                int minIndex = 0;

                /* The pivot.First is the pivot line
                 * The pivot line is the line in which min ratio k = "simplexTableau[i][0] / simplexTableau[i][pivot.Second]" is minim
                 * If we have more than one line with minim k, the line which corresponds to an auxiliary variable has priority
                 */
                List<double> minRatioList = new List<double>();
                for (int i = 0; i < nrRestrictions; i++)
                {
                    minRatioList.Add(Double.MaxValue);
                }

                for (int i = 0; i < nrRestrictions; i++) //computing min ratio for each line
                {
                    if (simplexTableau[i][pivot.Second] > 0)  //"simplexTableau[i][pivot.Second]" should be greater than zero
                    {
                        minRatioList[i] = (simplexTableau[i][0] / simplexTableau[i][pivot.Second]);
                    }
                }

                //if we have more lines with the same min ratio k, we create a list of those lines
                List<int> pivotCandidates = new List<int>();
                min = minRatioList.Min();
                pivotCandidates.Add(minRatioList.IndexOf(min));
                minRatioList[minRatioList.IndexOf(min)] = Double.MaxValue;

                for (int i = 0; i < minRatioList.Count; i++)
                {
                    if (minRatioList[i] == min)
                    {
                        pivotCandidates.Add(i); //computing pivot candidates according to minim ratio test
                    }
                }

                if (phase == 1)
                {
                    if (pivotCandidates.Count > 1)
                    {
                        for (int i = 0; i < pivotCandidates.Count; i++)
                        {
                            if (auxiliaryVariables.Contains(basis[pivotCandidates[i]]))
                            {
                                pivot.First = pivotCandidates[i]; //in the phase 1, line which corresponds to an auxiliary variable has priority
                                break;
                            }
                        }

                    }
                    else
                    {
                        pivot.First = pivotCandidates[0]; //if there is one candidate
                    }
                }
                else
                {
                    pivot.First = pivotCandidates[0]; //if we are in the phase 2
                }


                return true; //pivot was found
            }

            private void SimplexTableauProcessing(int phase)
            {
                //determining coefficients of the basic variable from the objective function
                List<double> coefBasicVarCol = new List<double>();
                for (int i = 0; i < basis.Count; i++)
                    coefBasicVarCol.Add(0);

                List<double> coefBasicVarLine = new List<double>();

                List<double> newObjectiveFunction = new List<double>();
                for (int i = 0; i < c.Count; i++)
                    newObjectiveFunction.Add(0);

                for (int i = 0; i < auxiliaryVariables.Count; i++)
                {
                    newObjectiveFunction[auxiliaryVariables[i]] = 1;
                }

                if (phase == 1)
                {
                    for (int i = 0; i < basis.Count; i++)
                    {
                        coefBasicVarCol[i] = newObjectiveFunction[basis[i]];
                    }

                    coefBasicVarLine = newObjectiveFunction;
                }

                if (phase == 2)
                {
                    for (int i = 0; i < basis.Count; i++)
                    {
                        coefBasicVarCol[i] = c[basis[i]];
                    }

                    coefBasicVarLine = c;
                }

                //Computing initial indicators and the value of the objective function
                for (int i = 0; i < simplexTableau[nrRestrictions].Count; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < basis.Count; j++)
                    {
                        sum += (coefBasicVarCol[j] * simplexTableau[j][i]);
                    }

                    simplexTableau[nrRestrictions][i] = sum - coefBasicVarLine[i];
                }

                while (!IsOptimal())
                {
                    FindPivot(phase);
                    double pivotValue = simplexTableau[pivot.First][pivot.Second];

                    double x = 5;

                    if (IsUnbounded())
                    {
                        err = 3;
                        break;
                    }
                    //Computing the new simplex tableau values
                    //computing elements which are not in pivot line and basic variables columns
                    for (int i = 0; i <= nrRestrictions; i++)
                    {
                        for (int j = 0; j < simplexTableau[nrRestrictions].Count; j++)
                        {
                            if (i != pivot.First && j != pivot.Second)
                            {
                                simplexTableau[i][j] =
                                    ((pivotValue * simplexTableau[i][j]) -
                                     (simplexTableau[pivot.First][j] * simplexTableau[i][pivot.Second])) /
                                    (pivotValue);
                            }
                        }
                    }

                    for (int i = 0; i < simplexTableau[nrRestrictions].Count; i++) //the line of pivot is divided by pivot
                    {
                        simplexTableau[pivot.First][i] /= pivotValue;
                    }

                    //computing the column of the pivot
                    for (int i = 0; i <= nrRestrictions; i++)
                    {
                        if (i != pivot.First)
                        {
                            simplexTableau[i][pivot.Second] = 0;
                        }
                    }

                    if (phase == 1 && auxiliaryVariables.Contains(basis[pivot.First])) //deleting the auxiliary variable
                    {
                        int deletedColumn = basis[pivot.First];
                        for (int i = 0; i <= nrRestrictions; i++) //delete auxiliary variable from simplex tableau
                        {
                            simplexTableau[i].RemoveAt(deletedColumn);
                        }

                        c.RemoveAt(deletedColumn);

                        //deleting "deletedColumn" element from the auxiliaryVariables list
                        auxiliaryVariables.Remove(deletedColumn);

                        //Decrementing indexes for avoiding out of range exception
                        for (int i = 0; i < nrRestrictions; i++)
                        {
                            if (basis[i] > deletedColumn)
                                basis[i]--;
                        }

                        for (int i = 0; i < auxiliaryVariables.Count; i++)
                        {
                            if (auxiliaryVariables[i] > deletedColumn)
                                auxiliaryVariables[i]--;
                        }
                    }

                    basis[pivot.First] = pivot.Second; //the column of the pivot becomes a basic variable
                }
            }

            private void SecondPhase()
            {
                SimplexTableauProcessing(2);
            }

            public void SimplexAlgorithm()
            {
                ConvertToStandardForm();
                FirstPhase();
                SecondPhase();
            }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            int control = 1;
            outputData.Text = "";

            int control_1 = rightStringInt(variablesNumber.Text, 1);
            if (control_1 == 1 && variablesNumber.Text != "")
                variables = Convert.ToInt32(variablesNumber.Text.Trim());
            else
            {
                control_1 = 0;
                outputData.Text += "\n\n Check Total Variables Data";
            }


            int control_2 = rightStringInt(constraintsNumber.Text, 1);
            if (control_2 == 1 && constraintsNumber.Text != "")
                restrictions = Convert.ToInt32(constraintsNumber.Text.Trim());
            else
            {
                control_2 = 0;
                outputData.Text += "\n\n Check Total Constraints Data";
            }


            if (control_1 == 1 && control_2 == 1)
            {
                if (checkMax.Checked == true)
                    maximize = 1;
                if (checkMin.Checked == true)
                    minimize = 1;

                if (checkMax.Checked != true && checkMin.Checked != true)
                {
                    outputData.Text += "\n Please select Operation ";
                    control = 0;
                }


                string[] inputObjectives = objectiveFunction.Text.Trim().Split(' ');
                if (variables == inputObjectives.Length)
                {
                    int k = 0;
                    while (k < inputObjectives.Length)
                    {
                        if (rightDouble(inputObjectives[k]) == 0)
                        {
                            outputData.Text += "\n\n Incorrect value " + Convert.ToString(k + 1) + "\n    in Objectiv Function";
                            control = 0;
                        }

                        k++;
                    }

                    objectiveValues = new double[inputObjectives.Length];
                    for (int i = 0; i < inputObjectives.Length && control == 1; i++)
                    {
                        NumberFormatInfo formatProvider = new NumberFormatInfo();
                        formatProvider.NumberDecimalSeparator = ".";
                        objectiveValues[i] = Convert.ToDouble(inputObjectives[i], formatProvider);
                    }
                }
                else
                {
                    outputData.Text += "\n\n Check Objective Function Data";
                    control = 0;
                }


                var inputLines = inputData.Text.Split('\n');
                equationValues = new double[inputLines.Length][];

                if (restrictions == inputLines.Length)
                {
                    int k = 0;
                    int t = 0;
                    foreach (var line in inputLines)
                    {
                        t++;
                        string[] stringValues = line.Trim().Split(' ');

                        if (variables == stringValues.Length)
                        {
                            int w = 0;
                            while (w < stringValues.Length)
                            {
                                if (rightDouble(stringValues[w]) == 0)
                                {
                                    outputData.Text += "\n\n Incorrect value " + Convert.ToString(w + 1) + " in constraint " + Convert.ToString(t);
                                    control = 0;
                                }
                                w++;
                            }
                            double[] intValues = new double[stringValues.Length];

                            for (int i = 0; i < stringValues.Length && control == 1; i++)
                            {
                                NumberFormatInfo formatProvider = new NumberFormatInfo();
                                formatProvider.NumberDecimalSeparator = ".";
                                intValues[i] = Convert.ToDouble(stringValues[i], formatProvider);
                            }
                            equationValues[k] = intValues;
                            k++;
                        }
                        else
                        {
                            outputData.Text += "\n\n Check number of parametres  \n                  in Constraint " + Convert.ToString(k + 1);
                            control = 0;
                            break;
                        }
                    }
                }
                else
                {
                    outputData.Text += "\n\n Check Subject to Constraints";
                    control = 0;
                }



                string[] inputSigns = inputSign.Text.Trim().Split('\n');
                equationSignes = new string[inputSigns.Length];

                if (restrictions == inputSigns.Length)
                {
                    int k = 0;
                    while (k < inputSigns.Length)
                    {
                        if (rightSign(inputSigns[k]) == 0)
                        {
                            outputData.Text += "\n\n Incorrect Sign " + Convert.ToString(k + 1);
                            control = 0;
                        }

                        k++;
                    }


                    for (int i = 0; i < inputSigns.Length && control == 1; i++)
                    {
                        int j = 0;

                        while (j < inputSigns[i].Length)
                        {
                            if (inputSigns[i][j] == '=')
                            {
                                equationSignes[i] += inputSigns[i][j];
                            }
                            else if (inputSigns[i][j] == '>' || inputSigns[i][j] == '<')
                            {
                                equationSignes[i] += inputSigns[i][j];
                            }

                            j++;
                        }
                    }
                }
                else
                {
                    outputData.Text += "\n\n Check the number of Signs";
                    control = 0;
                }



                var inputBB = inputB.Text.Trim().Split('\n');
                equationRezults = new double[inputBB.Length];

                if (restrictions == inputBB.Length)
                {
                    int k = 0;
                    while (k < inputBB.Length)
                    {
                        if (rightDouble(inputBB[k]) == 0)
                        {
                            outputData.Text += "\n\n Incorrect Free Term " + Convert.ToString(k + 1);
                            control = 0;
                        }

                        k++;
                    }

                    for (int i = 0; i < inputBB.Length && control == 1; i++)
                    {
                        NumberFormatInfo formatProvider = new NumberFormatInfo();
                        formatProvider.NumberDecimalSeparator = ".";
                        equationRezults[i] = Convert.ToDouble(inputBB[i], formatProvider);
                    }
                }
                else
                {
                    outputData.Text += "\n\n Check the number of Free Terms";
                    control = 0;
                }

                if (control == 1)
                {
                    if (maximize == 1)
                    {
                        Simplex a = new Simplex(variables, restrictions, equationSignes, objectiveValues, equationRezults, equationValues, -1);
                        a.SimplexAlgorithm();

                        double[] solutionVector = new double[variables];

                        for (int i = 0; i < a.nrRestrictions; i++)
                        {
                            if (a.basis[i] <= variables)
                            {
                                solutionVector[a.basis[i] - 1] = a.simplexTableau[i][0];
                            }
                        }

                        if (a.err == 0)
                        {
                            outputData.Text += "\nx = ( ";

                            for (int i = 0; i < variables; i++)
                            {
                                outputData.Text += Convert.ToString(solutionVector[i]);
                                if (i < variables - 1)
                                    outputData.Text += " , ";
                            }

                            outputData.Text += " )\nMax( z ) = " + Convert.ToString(-1 * a.simplexTableau[a.nrRestrictions][0]) + "\n";
                        }
                        else if (a.err == 1)
                        {
                            outputData.Text += "\n\nConflicting restrictions!";
                        }
                        else if (a.err == 2)
                        {
                            outputData.Text += "\n\nThere are auxiliary \n  variabiles in the basis, \n    the phase 2 can't be executed!";
                        }
                        else if (a.err == 3)
                        {
                            outputData.Text += "\n\nThe problem is unbounded!";
                        }
                    }
                    maximize = 0;

                    if (minimize == 1)
                    {
                        Simplex a = new Simplex(variables, restrictions, equationSignes, objectiveValues, equationRezults, equationValues);
                        a.SimplexAlgorithm();

                        double[] solutionVector = new double[variables];

                        for (int i = 0; i < a.nrRestrictions; i++)
                        {
                            if (a.basis[i] <= variables)
                            {
                                solutionVector[a.basis[i] - 1] = a.simplexTableau[i][0];
                            }
                        }

                        if (a.err == 0)
                        {
                            outputData.Text += "\nx = ( ";
                            for (int i = 0; i < variables; i++)
                            {
                                outputData.Text += Convert.ToString(solutionVector[i]);
                                if (i < variables - 1)
                                    outputData.Text += " , ";
                            }

                            outputData.Text += " )\nMin( z ) = " + Convert.ToString(a.simplexTableau[a.nrRestrictions][0]);
                        }
                        else if (a.err == 1)
                        {
                            outputData.Text += "\n\nConflicting restrictions!";
                        }
                        else if (a.err == 2)
                        {
                            outputData.Text += "\n\nThere are auxiliary \n  variabiles in the basis, \n    the phase 2 can't be executed!";
                        }
                        else if (a.err == 3)
                        {
                            outputData.Text += "\n\nThe problem is unbounded!";
                        }
                    }
                    minimize = 0;
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            objectiveFunction.Text = "";
            variablesNumber.Text = "";
            constraintsNumber.Text = "";
            inputData.Text = "";
            inputSign.Text = "";
            inputB.Text = "";
            outputData.Text = "";
            checkMax.Checked = false;
            checkMin.Checked = false;
        }
    }
}
