using Synchronize_Trackball;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronize_Trackball
{
    public class DataGenerator
    {
        public int DataCount = 100;
        private Random randomNumber;
        public ObservableCollection<Data> DataCollection1 { get; set; }
        public ObservableCollection<Data> DataCollection2 { get; set; }

        public DataGenerator()
        {
            randomNumber = new Random();
            DataCollection1 = GenerateData();
            DataCollection2 = GenerateData();
        }

        public ObservableCollection<Data> GenerateData()
        {
            ObservableCollection<Data> datas = new ObservableCollection<Data>();
            DateTime date = new DateTime(2020, 1, 1);
            double value = 100;

            for (int i = 0; i < DataCount; i++)
            {
                datas.Add(new Data(date, Math.Round(value, 2)));
                date = date.Add(TimeSpan.FromDays(1));

                if (randomNumber.NextDouble() > .5)
                {
                    value += randomNumber.NextDouble();
                }
                else
                {
                    value -= randomNumber.NextDouble();
                }
            }

            return datas;
        }
    }
}
