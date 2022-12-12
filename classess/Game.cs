using CommunityToolkit.Mvvm.ComponentModel;
using Juego_de_preguntas.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas.classess
{
    class Game : ObservableObject
    {
        private bool playing;

        public bool IsPlaying
        {
            get { return playing; }
            set { SetProperty(ref playing, value); }
        }

        private Question currQuestion;

        public Question CurrQuestion
        {
            get { return currQuestion; }
            set { SetProperty(ref currQuestion, value); }
        }

        private ObservableCollection<Question> questionList;

        public ObservableCollection<Question> QuestionList
        {
            get { return questionList; }
            set { SetProperty(ref questionList, value); }
        }

        private bool blueQ;

        public bool BlueQ
        {
            get { return blueQ; }
            set { SetProperty(ref blueQ, value); }
        }

        private bool orangeQ;

        public bool OrangeQ
        {
            get { return orangeQ; }
            set { SetProperty(ref orangeQ, value); }
        }

        private bool yellowQ;

        public bool YellowQ
        {
            get { return yellowQ; }
            set { SetProperty(ref yellowQ, value); }
        }

        private bool purpleQ;

        public bool PurpleQ
        {
            get { return purpleQ; }
            set { SetProperty(ref purpleQ, value); }
        }

        private bool greenQ;

        public bool GreenQ
        {
            get { return greenQ; }
            set { SetProperty(ref greenQ, value); }
        }

        private bool brownQ;

        public bool BrownQ
        {
            get { return brownQ; }
            set { SetProperty(ref brownQ, value); }
        }




        private DialogService dialogService = new DialogService();


        public Game()
        {
            Initialize();
            BlueQ = false;
            OrangeQ = false;
            YellowQ = false;
            PurpleQ = false;
            GreenQ = false;
            BrownQ = false;
        }

        private void Initialize()
        {
            QuestionList = new ObservableCollection<Question>();
        }




        public void Start(string dificulty, ObservableCollection<Question> list)
        {
            if (GetGameList(dificulty, list))
            {
                CurrQuestion = QuestionList.ElementAt(0);
            } else
            {
                dialogService.Error("No hay suficientes preguntas");
            }

        }

        public bool GetGameList(string dificulty, ObservableCollection<Question> list)
        {

            var query = list.GroupBy(
                    question => question.Category,
                    (k, v) => new
                    {
                        Key = k,
                        Count = v.Count(),
                        Viable = v.Any(),
                        Rnd = v.ElementAt(new Random().Next(0, v.Count()))
                    }
                ) ;

            bool allGood = true;
            
            
            
            foreach (var res in query)
            {
                if (!res.Viable)
                    allGood = false;
            }

            if (query.Count() != 6)
            {
                return false;
            }

            if (allGood)
            {

                foreach (var res in query)
                {
                    questionList.Add(res.Rnd);
                }

            }


            return allGood;
        }




    }
}
