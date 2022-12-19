using CommunityToolkit.Mvvm.ComponentModel;
using Juego_de_preguntas.classess;
using Juego_de_preguntas.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego_de_preguntas
{
    class MainWindowVM: ObservableObject
    {
        private Game currGame;
        public Game CurrGame
        {
            get { return currGame; }
            set { SetProperty(ref currGame, value); }
        }

            
        private Question addCurrQuestion;

        public Question AddCurrQuestion
        {
            get { return addCurrQuestion; }
            set { SetProperty(ref addCurrQuestion, value); }
        }

        private Question editCurrQuestion;

        public Question EditCurrQuestion
        {
            get { return editCurrQuestion; }
            set { SetProperty(ref editCurrQuestion, value); }
        }

        private ObservableCollection<Question> currQuestionList;

        public ObservableCollection<Question> CurrQuestionList
        {
            get { return currQuestionList; }
            set { SetProperty(ref currQuestionList, value); }
        }

        private ObservableCollection<string> categories;

        public ObservableCollection<string> Categories
        {
            get { return categories; }
            set { SetProperty(ref categories, value); }
        }

        private ObservableCollection<string> dificulties;

        public ObservableCollection<string> Dificulties
        {
            get { return dificulties; }
            set { SetProperty(ref dificulties, value); }
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



        private DialogService dialogService;
        private JsonService jsonService;
        public MainWindowVM()
        {
            currQuestionList = new ObservableCollection<Question>();
            EditCurrQuestion = null;

            dialogService = new DialogService();
            jsonService = new JsonService();
            // Extraer a método

            creaAddCurrQuestion();
            CreaEditCurrQuestion();

            CurrGame = null;
            Categories = new ObservableCollection<string> { "Arte y literatura", "Historia", "Deportes", "Ciencia", "Comida", "Ocio y Entretenimiento" };
            Dificulties = new ObservableCollection<string> { "Facil", "Medio", "Dificil"};
        }

        // ADD QUESTION
        public void creaAddCurrQuestion()
        {
            AddCurrQuestion = new Question();
            AddCurrQuestion.Category = "Arte y literatura";
            AddCurrQuestion.Dificulty = "Facil";
        }

        public void manageAddImage()
        {
            AddCurrQuestion.Image = BlobService.getBlob(dialogService.GetImagePath());
            
        }

        public void addQuestionToCurrQuestionList()
        {
            CurrQuestionList.Add((Question)addCurrQuestion.Clone());
            creaAddCurrQuestion();
        }

        // EDIT QUESTION


        public void deleteEditQuestion()
        {
            CurrQuestionList.Remove(EditCurrQuestion);
        }

        public void SaveJson()
        {
            jsonService.Save<ObservableCollection<Question>>(CurrQuestionList, dialogService.SaveJsonPath());
        }

        public void LoadJson()
        {
            CurrQuestionList = (ObservableCollection<Question>)jsonService.Open<ObservableCollection<Question>>(dialogService.GetJsonPath());
        }

        public void CreaEditCurrQuestion()
        {
            EditCurrQuestion = new Question();
            EditCurrQuestion.Category = "Arte y literatura";
            EditCurrQuestion.Dificulty = "Facil";
        }

        public void ManageAddPhoto()
        {
            EditCurrQuestion.Image = BlobService.getBlob(dialogService.GetImagePath());
        }
        // PLAY


        public void PlayGame()
        {
            int gIndex;
            CurrGame = new Game();
            gIndex = CurrGame.Play(Dificulties[DiffIndex], CurrQuestionList); 
            if (gIndex == -1)
            {
                CurrGame = null;
            }
        }

        public void Guess()
        {
            int gIndex;
            gIndex = CurrGame.Response(ResponseStr);

            if (gIndex == 6)
                CurrGame = null;
        }

        public void Restart()
        {
            CurrGame = null;
        }

    }
}
