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

        public int gameIndex;

        public int GameIndex
        {
            get { return gameIndex;  }
            set { SetProperty(ref gameIndex, value);  }
        }

        private string responseStr;

        public string ResponseStr
        {
            get { return responseStr; }
            set { SetProperty(ref responseStr, value); }
        }

        private int diffIndex;

        public int DiffIndex
        {
            get { return diffIndex; }
            set { SetProperty(ref diffIndex, value); }
        }

        private int MAX_QUESTIONS = 6;

        private DialogService dialogService = new DialogService();


        public Game()
        {
            Initialize();

        }

        private void Initialize()
        {
            QuestionList = new ObservableCollection<Question>();
            InitializeColors();


        }

        private void InitializeColors()
        {
            BlueQ = false;
            OrangeQ = false;
            YellowQ = false;
            PurpleQ = false;
            GreenQ = false;
            BrownQ = false;
        }




        public int Play(string dificulty, ObservableCollection<Question> list)
        {
            if (GetGameList(dificulty, list))
            {
                CurrQuestion = QuestionList.ElementAt(GameIndex);
                GameIndex = 0;
            } else
            {
                dialogService.Error("No hay suficientes preguntas");
            }
            return GameIndex;

        }

        public int Response(String response)
        {
            


            if ((CurrQuestion.CorrectAns ?? "NO_QUESTION") == (response.ToLower() ?? ""))
            {
                dialogService.Good("Acertaste!");
                EnableCheese();
                GameIndex++;
                if (GameIndex == MAX_QUESTIONS)
                {
                    dialogService.Good("Has ganado!!");
                    Initialize();
                    return GameIndex;
                }
                CurrQuestion = QuestionList[GameIndex];
            }
            else
                dialogService.Error("Fallaste");
            return GameIndex;

        }

        private void EnableCheese()
        {
            
            switch (CurrQuestion.Category)
            {
                case "Arte y literatura": GreenQ = true;
                    break;

                case "Historia": PurpleQ = true;
                    break;
                case "Deportes": YellowQ = true;
                    break;
                case "Ciencia": OrangeQ = true;
                    break;
                case "Comida": BlueQ = true;
                    break;
                default: BrownQ = true;
                    break;



            }
        }


        public bool GetGameList(string dificulty, ObservableCollection<Question> list)
        {

            var query = list
                .Where(x=> x.Dificulty == dificulty)
                .GroupBy(
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

            if (query.Count() != MAX_QUESTIONS)
            {
                return false;
            }

            if (allGood)
            {

                foreach (var res in query)
                {
                    QuestionList.Add(res.Rnd);
                }

            }


            return allGood;
        }




    }
}
