using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Naumaxia
{
    public partial class Form1 : Form
    {
        Random random = new Random();//Makes an object of Random class named random
        Random rand = new Random();//Makes an object of Random class named rand
        Random rand2 = new Random();//Makes an object of Random class named rand2
        Sea sea = new Sea();//Makes an object of Sea class named sea
        Sea sea2 = new Sea();//Makes an object of Sea class named sea2
        Aircraft_carrier Aircraftcarrier = new Aircraft_carrier();//Makes an object of Aircraft_carrier class named Aircraftcarrier
        Destroyer destroyer = new Destroyer();//Makes an object of Destroyer class named destroyer
        Warship warship = new Warship();//Makes an object of Warship class named warship
        Submarine submarine = new Submarine();//Makes an object of Submarine class named submarine
        List<int> Random_numbers = new List<int>();// Holds the random numbers that cannot be selectet by PC anymore
        int Gamer_wins = 0;//Holds how many wins Gamer has
        int PC_wins = 0;//Holds how many wins PC has
        int PC_seconds_counter = 0;//Holds how much time PC spent to win the game
        int Gamer_seconds_counter = 0;//Holds how much time Gamer spent to win the game
        public Form1()
        {
            InitializeComponent();
            groupBox1.Hide();
            Aircraftcarrier.A = 0;
            destroyer.D = 0;
            warship.W = 0;
            submarine.S = 0;
            sea.All = 0;
            Aircraftcarrier.A2 = 0;
            Aircraftcarrier.A2_destroyed = 0;
            destroyer.D2 = 0;
            destroyer.D2_destroyed = 0;
            warship.y_vertical = 0;
            warship.y_vertical_destroyed = 0;
            submarine.S2 = 0;
            submarine.S2_destroyed = 0;
            sea2.All2 = 0;

        }//Constructor of Form1()
        private void Form1_Load(object sender, EventArgs e)
        {
            MakeTables();
        }
        public void Make_Sea(int Table_Location_X)
        {
            int y = 52;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    bool control = true;
                    Label Label1 = new Label();
                    Label1.AutoSize = true;
                    Label1.BackColor = System.Drawing.Color.Blue;
                    Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    Label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
                    Label1.ForeColor = System.Drawing.Color.Lime;
                    Label1.Location = new System.Drawing.Point(j * 44 + Table_Location_X, i * 40 + y);
                    Label1.MinimumSize = new System.Drawing.Size(43, 40);
                    Label1.Name = "Label1";
                    Label1.Size = new System.Drawing.Size(43, 40);
                    Label1.TabIndex = 35;
                    Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    Controls.Add(Label1);
                    Label1.BringToFront();
                    if (Aircraftcarrier.ship[0].Location.Equals(Label1.Location) || Aircraftcarrier.ship[1].Location.Equals(Label1.Location) || Aircraftcarrier.ship[2].Location.Equals(Label1.Location) || Aircraftcarrier.ship[3].Location.Equals(Label1.Location) || Aircraftcarrier.ship[4].Location.Equals(Label1.Location))
                    {
                        Controls.Remove(Label1);
                        control = false;
                    }
                    else if (destroyer.ship[0].Location.Equals(Label1.Location) || destroyer.ship[1].Location.Equals(Label1.Location) || destroyer.ship[2].Location.Equals(Label1.Location) || destroyer.ship[3].Location.Equals(Label1.Location))
                    {
                        Controls.Remove(Label1);
                        control = false;
                    }
                    else if (warship.ship[0].Location.Equals(Label1.Location) || warship.ship[1].Location.Equals(Label1.Location) || warship.ship[2].Location.Equals(Label1.Location))
                    {
                        Controls.Remove(Label1);
                        control = false;
                    }
                    else if (submarine.ship[0].Location.Equals(Label1.Location) || submarine.ship[1].Location.Equals(Label1.Location))
                    {
                        Controls.Remove(Label1);
                        control = false;
                    }
                    if (Table_Location_X.Equals(55))
                    {
                        if (control)
                            sea.Water_Squaress.Add(Label1);//Puts the Labels in the List
                    }
                    else
                    {
                        Label1.Click += new System.EventHandler(Label_Click);
                        void Label_Click(object sender, EventArgs e)
                        {
                            if (timer2.Enabled)
                            {
                                Label1.Text = "-";
                                sea2.All2++;
                                timer1.Enabled = true;
                                timer2.Enabled = false;
                                timer3.Enabled = false;
                                timer4.Enabled = true;
                                label51.Text = "00:30";
                            }
                        }
                    }
                }
            }
        }//Makes the Tables
        public void Make_Aircraft_carrier(KnownColor color, int Table_Location_X, int IsPC)
        {
            int Is_horizontal = random.Next(2);// Variable that indicates if the Ship is Horizontal or Vertical
            int y_horizontal = random.Next(10);//Variable that holds the line that the Ship will be created
            int x_horizontal = random.Next(6);//Variable that holds the collum that that the first label of the Ship will be created
            int y_vertical = random.Next(6);//Variable that holds the collum that the Ship will be created
            int x_vertical = random.Next(10);//Variable that holds the line that the first label of the Ship will be created
            Make_Ship(Aircraftcarrier.Size, Is_horizontal, y_horizontal, x_horizontal, y_vertical, x_vertical, Aircraftcarrier, color, Table_Location_X, IsPC);//We use the horizontal variables if the ship is horizontal and the same for the vertical variables
        }//Creates 5 variables and then calls Make_Ship method
        public void Make_Destroyer(KnownColor color, int Table_Location_X, int IsPC)
        {
            int Is_horizontal = random.Next(2);
            int y_horizontal = random.Next(10);
            int x_horizontal = random.Next(7);//we take random numbers from 0 to 6 ,we do it so that the ship fits in the table
            int y_vertical = random.Next(7);
            int x_vertical = random.Next(10);
            int y = 52;
            int times = 0;
            List<int> X = new List<int>();
            List<int> Y = new List<int>();
            X.Add(x_vertical);
            Y.Add(y_horizontal);
            while (times < 10)
            {
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        if (((Aircraftcarrier.ship[i].Location.X.Equals(j * 44 + Table_Location_X)) && (Aircraftcarrier.ship[i].Location.Y.Equals(y_horizontal * 40 + y))))//Checks if the y_horizontal(line) have any ship in it if so take other but not the same y_horizontal(line)
                        {
                            do
                            {
                                y_horizontal = random.Next(10);
                            } while (Y.Contains(y_horizontal) && !(Y.Count > 9));
                            Y.Add(y_horizontal);
                        }
                        if (((Aircraftcarrier.ship[i].Location.X.Equals(x_vertical * 44 + Table_Location_X)) && (Aircraftcarrier.ship[i].Location.Y.Equals(j * 40 + y))))//Checks if the x_vertical(collum) have any ship in it if so take other but not the same x_vertical(collum)
                        {
                            do
                            {
                                x_vertical = random.Next(10);
                            } while (X.Contains(x_vertical) && !(X.Count > 9));
                            X.Add(x_vertical);
                        }
                    }
                times++;
            }
            Make_Ship(destroyer.Size, Is_horizontal, y_horizontal, x_horizontal, y_vertical, x_vertical, destroyer, color, Table_Location_X, IsPC);

        }//Checks if the Destroyer can be created and if it can it calls Make_Ship method
        public void Make_Warship(KnownColor color, int Table_Location_X, int IsPC)
        {
            int Is_horizontal = random.Next(2);
            int y_horizontal = random.Next(10);
            int x_horizontal = random.Next(8);
            int y_vertical = random.Next(8);
            int x_vertical = random.Next(10);
            int y = 52;

            List<int> X = new List<int>();
            List<int> Y = new List<int>();
            X.Add(x_vertical);
            Y.Add(y_horizontal);
            int times = 0;
            while (times < 10)
            {
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 4; j++)
                        for (int z = 0; z < 10; z++)
                        {
                            if (((Aircraftcarrier.ship[i].Location.X.Equals(z * 44 + Table_Location_X) && Aircraftcarrier.ship[i].Location.Y.Equals(y_horizontal * 40 + y)) || (destroyer.ship[j].Location.X.Equals(z * 44 + Table_Location_X) && destroyer.ship[j].Location.Y.Equals(y_horizontal * 40 + y))))//Checks if the y_horizontal(line) have any ship in it if so take other but not the same y_horizontal(line)



                            {
                                do
                                {
                                    y_horizontal = random.Next(10);
                                } while (Y.Contains(y_horizontal) && !(Y.Count > 9));
                                Y.Add(y_horizontal);
                            }
                            if (((Aircraftcarrier.ship[i].Location.X.Equals(x_vertical * 44 + Table_Location_X) && Aircraftcarrier.ship[i].Location.Y.Equals(z * 40 + y)) || (destroyer.ship[j].Location.X.Equals(x_vertical * 44 + Table_Location_X) && destroyer.ship[j].Location.Y.Equals(z * 40 + y))))//Checks if the x_vertical(collum) have any ship in it if so take other but not the same x_vertical(collum)
                            {
                                do
                                {
                                    x_vertical = random.Next(10);
                                } while (X.Contains(x_vertical) && !(X.Count > 9));
                                X.Add(x_vertical);
                            }
                        }
                times++;
            }
            Make_Ship(warship.Size, Is_horizontal, y_horizontal, x_horizontal, y_vertical, x_vertical, warship, color, Table_Location_X, IsPC);
        }//Checks if the Warship can be created and if it can it calls Make_Ship method
        public void Make_Submarine(KnownColor color, int Table_Location_X, int IsPC)
        {
            int Is_horizontal = random.Next(2);
            int y_horizontal = random.Next(10);
            int x_horizontal = random.Next(9);
            int y_vertical = random.Next(9);
            int x_vertical = random.Next(10);
            int y = 52;
            List<int> X = new List<int>();
            List<int> Y = new List<int>();
            X.Add(x_vertical);
            Y.Add(y_horizontal);

            int times = 0;
            while (times < 10)
            {
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 4; j++)
                        for (int z = 0; z < 3; z++)
                            for (int p = 0; p < 10; p++)
                            {
                                if (((Aircraftcarrier.ship[i].Location.X.Equals(p * 44 + Table_Location_X) && Aircraftcarrier.ship[i].Location.Y.Equals(y_horizontal * 40 + y))//Checks if the y_horizontal(line) have any ship in it if so take other but not the same y_horizontal(line)
                                || (destroyer.ship[j].Location.X.Equals(p * 44 + Table_Location_X) && destroyer.ship[j].Location.Y.Equals(y_horizontal * 40 + y))
                                || (warship.ship[z].Location.X.Equals(p * 44 + Table_Location_X) && warship.ship[z].Location.Y.Equals(y_horizontal * 40 + y))))



                                {
                                    do
                                    { //if y_horizontal exists in Y try again while Y<10
                                        y_horizontal = random.Next(10);
                                    } while (Y.Contains(y_horizontal) && !(Y.Count > 9));
                                    Y.Add(y_horizontal);
                                }
                                if ((Aircraftcarrier.ship[i].Location.X.Equals(x_vertical * 44 + Table_Location_X) && Aircraftcarrier.ship[i].Location.Y.Equals(p * 40 + y))//Checks if the x_vertical(collum) have any ship in it if so take other but not the same x_vertical(collum)
                                || (destroyer.ship[j].Location.X.Equals(x_vertical * 44 + Table_Location_X) && destroyer.ship[j].Location.Y.Equals(p * 40 + y))
                                || (warship.ship[z].Location.X.Equals(x_vertical * 44 + Table_Location_X) && warship.ship[z].Location.Y.Equals(p * 40 + y)))
                                {
                                    do //if x_vertical exists in X try again while X<10
                                    {
                                        x_vertical = random.Next(10);
                                    } while (X.Contains(x_vertical) && !(X.Count > 9));
                                    X.Add(x_vertical);
                                }
                            }


                times++;
            }

            Make_Ship(submarine.Size, Is_horizontal, y_horizontal, x_horizontal, y_vertical, x_vertical, submarine, color, Table_Location_X, IsPC);



        }//Checks if the Submarine can be created and if it can it calls Make_Ship method
        public void Make_Ship(int Ship_size, int Ishorizontal, int y_horizontal, int x_horizontal, int y_vertical, int x_vertical, Aircraft_carrier s, KnownColor c, int Table_Location_X, int IsPC)
        {
            int y = 52;
            for (int j = 0; j < Ship_size; j++)
            {
                bool flag1 = true;
                Label aircraft_carrier = new Label();
                aircraft_carrier.AutoSize = true;
                aircraft_carrier.BackColor = System.Drawing.Color.FromKnownColor(c);
                aircraft_carrier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                aircraft_carrier.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                aircraft_carrier.Name = "aircraft_carrier1";
                aircraft_carrier.ForeColor = System.Drawing.Color.Red;
                aircraft_carrier.MinimumSize = new System.Drawing.Size(43, 40);
                aircraft_carrier.Size = new System.Drawing.Size(43, 40);
                aircraft_carrier.TabIndex = 35;
                aircraft_carrier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                if (Ishorizontal.Equals(1))
                {
                    aircraft_carrier.Location = new System.Drawing.Point(x_horizontal * 44 + Table_Location_X, y_horizontal * 40 + y);
                    Table_Location_X += 44;
                }
                else
                {
                    aircraft_carrier.Location = new System.Drawing.Point(x_vertical * 44 + Table_Location_X, y_vertical * 40 + y);
                    y += 40;
                }

                if (IsPC.Equals(2))
                {
                    aircraft_carrier.Click += new System.EventHandler(aircraft_carrier_Click);
                    void aircraft_carrier_Click(object sender, EventArgs e)
                    {
                        if (timer2.Enabled && !aircraft_carrier.Text.Equals("X"))
                        {
                            if (flag1)
                            {
                                if (Ship_size.Equals(5))
                                {
                                    Aircraftcarrier.A2++;
                                    sea2.All2++;
                                }
                                else if (Ship_size.Equals(4))
                                {
                                    destroyer.D2++;
                                    sea2.All2++;
                                }
                                else if (Ship_size.Equals(3))
                                {
                                    warship.y_vertical++;
                                    sea2.All2++;
                                }
                                else if (Ship_size.Equals(2))
                                {
                                    submarine.S2++;
                                    sea2.All2++;
                                }
                                if (Aircraftcarrier.A2.Equals(5) && Aircraftcarrier.A2_destroyed.Equals(0))
                                {
                                    MessageBox.Show("βυθίστηκε το Αεροπλανοφόρο !");
                                    Aircraftcarrier.A2_destroyed++;
                                }
                                else if (destroyer.D2.Equals(4) && destroyer.D2_destroyed.Equals(0))
                                {
                                    MessageBox.Show("βυθίστηκε το Αντιτορπιλικό !");
                                    destroyer.D2_destroyed++;
                                }
                                else if (warship.y_vertical.Equals(3) && warship.y_vertical_destroyed.Equals(0))
                                {
                                    MessageBox.Show("βυθίστηκε το Πολεμικό !");
                                    warship.y_vertical_destroyed++;
                                }
                                else if (submarine.S2.Equals(2) && submarine.S2_destroyed.Equals(0))
                                {
                                    MessageBox.Show("βυθίστηκε το Υποβρύχιο !");
                                    submarine.S2_destroyed++;
                                }
                                aircraft_carrier.Text = "X";
                                flag1 = false;
                                if ((Aircraftcarrier.A2 + destroyer.D2 + warship.y_vertical + submarine.S2).Equals(14))
                                {
                                    timer1.Enabled = false;
                                    timer2.Enabled = false;
                                    timer3.Enabled = false;
                                    timer4.Enabled = false;
                                    label51.Text = "00:30";
                                    label52.Text = "00:30";
                                    Gamer_wins++;
                                    label10.Text = Gamer_seconds_counter.ToString() + " seconds";
                                    label9.Text = "" + sea2.All2;
                                    label3.Text = "" + Gamer_wins;
                                    MessageBox.Show("Congratulations Gamer!! you won against PC ");
                                    try
                                    {
                                        SaveResultsToDB("Gamer", (PC_seconds_counter + Gamer_seconds_counter).ToString());
                                    }
                                    catch (Exception E)
                                    {
                                        Console.WriteLine(E.Message);
                                    }
                                    groupBox1.BringToFront();
                                    groupBox1.Show();
                                }
                            }
                            if (!(Aircraftcarrier.A2 + destroyer.D2 + warship.y_vertical + submarine.S2).Equals(14))
                            {
                                timer1.Enabled = true;
                                timer4.Enabled = true;
                            }
                            timer2.Enabled = false;
                            timer3.Enabled = false;
                            label51.Text = "00:30";
                        }
                    }
                }
                else
                    sea.Water_Squaress.Add(aircraft_carrier);//puts the Aircraft_carrier ship in the List (all the ships are Aircraft_carrier because they extend Aircraft_carrier class)



                Controls.Add(aircraft_carrier);
                aircraft_carrier.BringToFront();
                s.ship[j] = aircraft_carrier;




            }
        }//Creates the Ships
        public class Sea
        {
            public List<Label> Water_Squaress = new List<Label>();//A List that holds all labels of the Gamer_table and we use it for the PC to hit the ships
            public int All { get; set; } //Amount of times Labels of Sea1 has been selected (auto property)
            public int All2 { get; set; } //Amount of times Labels of Sea2 has been selected (auto property)
            public Sea()
            {
            }
        }// Sea class contains the characteristics of the Sea
        public class Aircraft_carrier : Sea
        {
            public int Size { get; set; } //the size of the Aircraft_carrier (auto property)
            public int A { get; set; } //Amount of times Aircraft_carrier has been hit (auto property)
            public int A2 { get; set; } //Amount of times Aircraft_carrier2 has been hit (auto property)
            public int A2_destroyed { get; set; } //Counter that indicates that Aircraft_carrier2 is destroyed (auto property)

            public Label[] ship { get; set; }
            public Aircraft_carrier()
            {
                Size = 5;
                ship = new Label[Size];
            }
        }// Aircraft_carrier class contains the characteristics of the Aircraft_carrier ship
        public class Destroyer : Aircraft_carrier
        {
            public int D { get; set; } //Amount of times Destroyer has been hit (auto property) (Destroyer is the ship of the PC)
            public int D2 { get; set; } //Amount of times Destroyer2 has been hit (auto property) (Destroyer 2 is the ship of the PC)
            public int D2_destroyed { get; set; } //Counter that indicates that Destroyer2 is destroyed (auto property)
            public Destroyer()
            {
                Size = 4;
                ship = new Label[Size];
            }
        }// Destroyer class contains the characteristics of the Destroyer ship
        public class Warship : Aircraft_carrier
        {
            public int W { get; set; } //Amount of times Warship has been hit (auto property)
            public int y_vertical { get; set; } //Amount of times Warship2 has been hit (auto property)
            public int y_vertical_destroyed { get; set; } //Counter that indicates that Warship2 is destroyed (auto property)
            public Warship()
            {
                Size = 3;
                ship = new Label[Size];
            }
        }// Warship class contains the characteristics of the Warship ship
        public class Submarine : Aircraft_carrier
        {
            public int S { get; set; } //Amount of times Submarine has been hit (auto property)
            public int S2 { get; set; } //Amount of times Submarine2 has been hit (auto property)
            public int S2_destroyed { get; set; } //Counter that indicates that Submarine2 is destroyed (auto property)
            public Submarine()
            {
                Size = 2;
                ship = new Label[Size];
            }
        }// Submarine class contains the characteristics of the Submarine ship
        private void Disappear()
        {
            while (Controls.Count > 247)
            {
                Controls.RemoveAt(Controls.Count - 47);
            }
        }//Makes the Labels disappear woooow
        private void timer1_Tick(object sender, EventArgs e)
        {
            int number;
            int random = rand2.Next(1, 30) * 100;
            timer1.Interval = random;
            if (Random_numbers.Count > 99)
            {
                timer1.Enabled = false;
                timer4.Enabled = false;
                label52.Text = "00:30";
            }
            do
            {
                number = rand.Next(100);



            } while (Random_numbers.Contains(number));
            Random_numbers.Add(number);
            if ((sea.Water_Squaress.ElementAt(number).Name.Equals("Label1")))
            {
                sea.Water_Squaress.ElementAt(number).Text = "-";
                sea.All++;
            }
            else if ((number.Equals(0))
            || (number.Equals(1))
            || (number.Equals(2))
            || (number.Equals(3))
            || (number.Equals(4)))
            {
                sea.Water_Squaress.ElementAt(number).Text = "X";
                sea.All++;
                Aircraftcarrier.A++;
                if (Aircraftcarrier.A == 5)
                    MessageBox.Show("βυθίστηκε το Αεροπλανοφόρο !");



            }
            else if ((number.Equals(5)) ||
            (number.Equals(6)) ||
            (number.Equals(7)) ||
            (number.Equals(8)))
            {
                sea.Water_Squaress.ElementAt(number).Text = "X";
                sea.All++;
                destroyer.D++;
                if (destroyer.D == 4)
                    MessageBox.Show("βυθίστηκε το Αντιτορπιλικό !");
            }
            else if ((number.Equals(9))
            || (number.Equals(10))
            || (number.Equals(11)))
            {
                sea.Water_Squaress.ElementAt(number).Text = "X";
                sea.All++;
                warship.W++;
                if (warship.W == 3)
                    MessageBox.Show("βυθίστηκε το Πολεμικό !");
            }
            else if ((number.Equals(12))
            || (number.Equals(13)))
            {
                sea.Water_Squaress.ElementAt(number).Text = "X";
                sea.All++;
                submarine.S++;
                if (submarine.S == 2)
                    MessageBox.Show("βυθίστηκε το Υποβρύχιο !");
            }
            if ((Aircraftcarrier.A + destroyer.D + warship.W + submarine.S).Equals(14))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                label51.Text = "00:30";
                label52.Text = "00:30";
                PC_wins++;
                label10.Text = PC_seconds_counter.ToString() + " seconds";
                label9.Text = "" + sea.All;
                label1.Text = "" + PC_wins;
                MessageBox.Show("Congratulations PC!! you won against Gamer ");
                SaveResultsToDB("PC", (PC_seconds_counter + Gamer_seconds_counter).ToString());
                groupBox1.BringToFront();
                groupBox1.Show();
            }
            if (!(Aircraftcarrier.A + destroyer.D + warship.W + submarine.S).Equals(14))
            {
                timer2.Enabled = true;
                timer3.Enabled = true;
            }
            timer1.Enabled = false;
            timer4.Enabled = false;
            label52.Text = "00:30";
        }//timer1_tick is the code for PC that hits different labels of Gamer_table to sink a ship
        private void Quit(object sender, EventArgs e)
        {
            Application.Exit();
        }//Exits the Application
        private void Restart_Game(object sender, EventArgs e)
        {
            groupBox1.Hide();
            Aircraftcarrier.A = 0;
            destroyer.D = 0;
            warship.W = 0;
            submarine.S = 0;
            sea.All = 0;
            Aircraftcarrier.A2 = 0;
            Aircraftcarrier.A2_destroyed = 0;
            destroyer.D2 = 0;
            destroyer.D2_destroyed = 0;
            warship.y_vertical = 0;
            warship.y_vertical_destroyed = 0;
            submarine.S2 = 0;
            submarine.S2_destroyed = 0;
            sea2.All2 = 0;
            PC_seconds_counter = 0;
            Gamer_seconds_counter = 0;
            sea.Water_Squaress.Clear();
            MakeTables();
            Disappear();
        }//Restart the Game
        private void timer3_Tick(object sender, EventArgs e)
        {
            TimeCounter(sender, timer2, timer1, timer4, label51, "timer3");
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            TimeCounter(sender, timer1, timer2, timer3, label52, "timer4");
        }
        private void TimeCounter(object sender, Timer t1, Timer t2, Timer t3, Label label, string name)
        {
            Timer t4 = (Timer)sender;
            string text = label.Text;
            int seconds = int.Parse(text[3].ToString() + text[4].ToString());

            if (name.Equals("timer4")) PC_seconds_counter++; //The time that PC spent to win
            else Gamer_seconds_counter++; //The time that Gamer spent to win

            label.Text = --seconds < 10 ? "00:0" + seconds.ToString() : "00:" + seconds.ToString();

            if (seconds < 0)
            {
                t2.Enabled = true;
                t3.Enabled = true;
                label.Text = "00:30";
                t1.Enabled = false;
                t4.Enabled = false;
            }
        }
        private void SaveResultsToDB(string winner, string duration)
        {
            ConnectionClass conn = new ConnectionClass();
            const string query =
            "INSERT INTO Stats Values(@winner, @duration);";// @winner => avoid SQL injection.
            conn.OpenConnection();
            conn.CreateQuery(query);
            conn.ExecuteInsertQuery(winner, duration);
            conn.CloseConnection();
        }
        private void ShowResults_Click(object sender, EventArgs e)
        {
            ConnectionClass conn = new ConnectionClass();
            const string query = "SELECT * FROM Stats;";
            conn.OpenConnection();
            conn.CreateQuery(query);
            var results = conn.ExecuteShowQuery();
            conn.CloseConnection();
            MessageBox.Show("Winner name:       Duration:" + Environment.NewLine + results.ToString());
        }
        private void ClearDatabase_Click(object sender, EventArgs e)
        {
            ConnectionClass conn = new ConnectionClass();
            const string query = "DELETE FROM Stats;";
            conn.OpenConnection();
            conn.CreateQuery(query);
            conn.ExecuteDeleteQuery();
            conn.CloseConnection();
        }
        private void MakeTables()
        {//Creates both tables and starts the timers
            Make_Aircraft_carrier(KnownColor.Black, 55, 1);
            Make_Destroyer(KnownColor.Purple, 55, 1);
            Make_Warship(KnownColor.Yellow, 55, 1);
            Make_Submarine(KnownColor.Green, 55, 1);
            Make_Sea(55);
            Make_Aircraft_carrier(KnownColor.MediumPurple, 655, 2);
            Make_Destroyer(KnownColor.DeepPink, 655, 2);
            Make_Warship(KnownColor.HotPink, 655, 2);
            Make_Submarine(KnownColor.LightPink, 655, 2);
            Make_Sea(655);
            timer1.Enabled = true;
            timer4.Enabled = true;
            timer2.Enabled = false;
            timer3.Enabled = false;
        }
    }
}