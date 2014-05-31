using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace LessonPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Configuration.Instance.ParseFile("");
            //Schedule schedule = new Schedule(2, 2, 80, 3);
            Algorithm algorithm = new Algorithm(100, 8, 5);
            algorithm.Start();
            var bestSchedule = algorithm.GetBestChromosome();
            Save(bestSchedule);
        }

        private void Save(Schedule schedule)
        {
            var result = new StringBuilder();

            result.Append(string.Format("{0,-20}", ""));

            for (int i = 0; i < Consts.DayCount; ++i)
                result.Append(string.Format("{0,-233}", string.Format("Dzień {0}", i + 1)));

            result.Append("\n");
            result.Append("\n");
            result.Append(string.Format("{0,20}", ""));

            for (int i = 0; i < Consts.DayCount; ++i)
                for (int j = 0; j < Configuration.Instance.GetNumberOfRooms(); ++j)
                    result.Append(string.Format("{0,-114}", string.Format("Sala {0}", Configuration.Instance.GetRoomById(j).Name)));

            result.Append("\n");
            result.Append("\n");

            for (int i = 0; i < Consts.DayHours; ++i)
            {
                result.Append(string.Format("{0,-17}", string.Format("{0} : 00", 8 + i)));

                for (int j = 0; j < Consts.DayCount; ++j)
                    for (int k = 0; k < Configuration.Instance.GetNumberOfRooms(); ++k)
                    {
                        var found = false;
                        foreach (var el in schedule.Classes)
                        {
                            var nr = Configuration.Instance.GetNumberOfRooms();
                            var key = el.Key;
                            int p = el.Value;
                            int t = p % (nr * Consts.DayHours);
                            int d = p / (nr * Consts.DayHours) + 1;
                            int r = t / Consts.DayHours;
                            t = t % Consts.DayHours + 1;
                            int l = r % 2;
                            int m = r / 2;

                            var courseName = key.Course.Name;
                            var groupName = string.Concat(key.StudentGroups.Select(x => x.Name + ", "));
                            var professorName = key.Professor.Name;
                            var time = key.LessonDuration;
                            var lab = key.IsLabRequired;

                            if (r == k && d == j && t == i)
                            {
                                var msg = string.Format("{0}, {1}, {2}, {3}, {4}/", courseName, groupName, professorName, lab, el.Key.LessonDuration);
                                result.Append(msg.PadRight(120 - msg.Length));
                                found = true;
                            }
                        }
                        if (!found)
                            result.Append(string.Format("{0,-120}", ""));
                        //result.Append("\t\t");
                    }

                result.Append("\n\n");
            }


            result.Append("\n\n\nWszystkie wyniki:\n\n");
            foreach (var el in schedule.Classes)
            {
                var nr = Configuration.Instance.GetNumberOfRooms();
                var key = el.Key;
                int p = el.Value;
                int t = p % (nr * Consts.DayHours);
                int d = p / (nr * Consts.DayHours) + 1;
                int r = t / Consts.DayHours;
                t = t % Consts.DayHours + 1;
                int l = r % 2;
                int m = r / 2;

                var courseName = key.Course.Name;
                var groupName = string.Concat(key.StudentGroups.Select(x => x.Name + ", "));
                var professorName = key.Professor.Name;
                var time = key.LessonDuration;
                var lab = key.IsLabRequired;
                var textBox = new TextBlock
                {
                    Text =
                        string.Format("Kurs: {0}\nGrupa: {1}\nProfesor: {2}\nLab: {3}", courseName, groupName,
                            professorName, lab)
                };
                Grid.SetColumn(textBox, d + l);
                Grid.SetRow(textBox, t + 2);
                Grid.SetRowSpan(textBox, time);
                MainGrid.Children.Add(textBox);

                //result.Append();
                result.Append("\n\n");
            }


            //this.result.Content = result;
        }
    }
}
