using MarcTron.Plugin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ThingsInEnglish.ApplicationContextDB;
using ThingsInEnglish.Helpers;
using ThingsInEnglish.Models;
using ThingsInEnglish.Views;
using Xamarin.Forms;

namespace ThingsInEnglish.ViewModes
{
    public class VM_PageHome : BaseVM
    {
        #region Constructor

        private ApplicationContext_DB _dbContext = new ApplicationContext_DB();

        public VM_PageHome(INavigation navigation)
        {
            Navigation = navigation;

            ThemeApp = LocalStorange.GetLocalStorange("theme");
            ColorFramePrincipal = Xamarin.Forms.Color.FromHex("333333");

            LabelPoints = 10;
            LabelTime = 99;

            if (ThemeApp == "Dark")
            {
                Theme();
            }
            else
            {
                Theme();
            }

            GenerateThingAletory();
            GenerateFramesThingAletory();
        }

        #endregion Constructor

        #region Properties

        private string _themeApp;
        private ImageSource _imageTheme;
        private int _timeAppMax;
        private int _labelPoints;
        private int _labelTime;
        private Color _colorFramePrincipal;
        private ImageSource _imageRandom;
        private int _idThing;
        private string _textFrame1;
        private string _textFrame2;
        private string _textFrame3;
        private string _textFrame4;
        private string _textFrame5;
        private string _textFrame6;
        private Color _colorFrame1;
        private Color _colorFrame2;
        private Color _colorFrame3;
        private Color _colorFrame4;
        private Color _colorFrame5;
        private Color _colorFrame6;
        private Color _theme;
        private bool _correct;

        #endregion Properties

        #region Objects

        public ImageSource ImageTheme
        {
            get => _imageTheme;
            set => SetProperty(ref _imageTheme, value);
        }

        public bool Correct
        {
            get => _correct;
            set => SetProperty(ref _correct, value);
        }

        public int TimeAppMax
        {
            get => _timeAppMax;
            set => SetProperty(ref _timeAppMax, value);
        }

        public int LabelPoints
        {
            get => _labelPoints;
            set => SetProperty(ref _labelPoints, value);
        }

        public int LabelTime
        {
            get => _labelTime;
            set => SetProperty(ref _labelTime, value);
        }

        public Color ColorFramePrincipal
        {
            get => _colorFramePrincipal;
            set => SetProperty(ref _colorFramePrincipal, value);
        }

        public ImageSource ImageRandom
        {
            get => _imageRandom;
            set => SetProperty(ref _imageRandom, value);
        }

        public int IdThing
        {
            get => _idThing;
            set => SetProperty(ref _idThing, value);
        }

        public string TextFrame1
        {
            get => _textFrame1;
            set => SetProperty(ref _textFrame1, value);
        }

        public string TextFrame2
        {
            get => _textFrame2;
            set => SetProperty(ref _textFrame2, value);
        }

        public string TextFrame3
        {
            get => _textFrame3;
            set => SetProperty(ref _textFrame3, value);
        }

        public string TextFrame4
        {
            get => _textFrame4;
            set => SetProperty(ref _textFrame4, value);
        }

        public string TextFrame5
        {
            get => _textFrame5;
            set => SetProperty(ref _textFrame5, value);
        }

        public string TextFrame6
        {
            get => _textFrame6;
            set => SetProperty(ref _textFrame6, value);
        }

        public Color ColorFrame1
        {
            get => _colorFrame1;
            set => SetProperty(ref _colorFrame1, value);
        }

        public Color ColorFrame2
        {
            get => _colorFrame2;
            set => SetProperty(ref _colorFrame2, value);
        }

        public Color ColorFrame3
        {
            get => _colorFrame3;
            set => SetProperty(ref _colorFrame3, value);
        }

        public Color ColorFrame4
        {
            get => _colorFrame4;
            set => SetProperty(ref _colorFrame4, value);
        }

        public Color ColorFrame5
        {
            get => _colorFrame5;
            set => SetProperty(ref _colorFrame5, value);
        }

        public Color ColorFrame6
        {
            get => _colorFrame6;
            set => SetProperty(ref _colorFrame6, value);
        }

        public Color Thema
        {
            get => _theme;
            set => SetProperty(ref _theme, value);
        }

        public string ThemeApp
        {
            get => _themeApp;
            set => SetProperty(ref _themeApp, value);
        }

        private int[] IdWordData = { 1, 2, 3, 4, 5, 6 };

        #endregion Objects

        #region Methods

        public async void GenerateThingAletory()
        {
            var thing = await _dbContext.Thing.Where(x => x.IdThing == RandomThing.GetRandomThing()).FirstOrDefaultAsync();

            ImageRandom = ConvertImage.ToPNG(thing.ImageBase64);

            IdThing = thing.IdThing;
        }

        public async void GenerateFramesThingAletory()
        {
            List<int> dataRandom = RandomThing.ThingAletory(5);

            var ThingOne = await _dbContext.Thing.Where(x => x.IdThing == IdThing).FirstOrDefaultAsync();
            var ThingTwo = await _dbContext.Thing.Where(x => x.IdThing == dataRandom[0]).FirstOrDefaultAsync();
            var ThingThree = await _dbContext.Thing.Where(x => x.IdThing == dataRandom[1]).FirstOrDefaultAsync();
            var ThingFour = await _dbContext.Thing.Where(x => x.IdThing == dataRandom[2]).FirstOrDefaultAsync();
            var ThingFive = await _dbContext.Thing.Where(x => x.IdThing == dataRandom[3]).FirstOrDefaultAsync();
            var ThingSix = await _dbContext.Thing.Where(x => x.IdThing == dataRandom[4]).FirstOrDefaultAsync();

            var random = new Random();

            var thingRandom = random.Next(1, 5);

            if (thingRandom == 1)
            {
                TextFrame1 = ThingOne.Name;
                TextFrame2 = ThingTwo.Name;
                TextFrame3 = ThingThree.Name;
                TextFrame4 = ThingFour.Name;
                TextFrame5 = ThingFive.Name;
                TextFrame6 = ThingSix.Name;

                IdWordData[0] = IdThing;

                ColorFrame1 = Xamarin.Forms.Color.FromHex("005DFF");
                ColorFrame2 = Color.Violet;
                ColorFrame3 = Xamarin.Forms.Color.FromHex("ADADAD"); ;
                ColorFrame4 = Color.Orange;
                ColorFrame5 = Color.Gold;
                ColorFrame6 = Color.Aqua;
            }
            else if (thingRandom == 2)
            {
                TextFrame2 = ThingOne.Name;
                TextFrame1 = ThingTwo.Name;
                TextFrame3 = ThingThree.Name;
                TextFrame4 = ThingFour.Name;
                TextFrame5 = ThingFive.Name;
                TextFrame6 = ThingSix.Name;

                IdWordData[1] = IdThing;

                ColorFrame4 = Xamarin.Forms.Color.FromHex("005DFF");
                ColorFrame1 = Color.Violet;
                ColorFrame5 = Xamarin.Forms.Color.FromHex("ADADAD"); ;
                ColorFrame6 = Color.Orange;
                ColorFrame2 = Color.Gold;
                ColorFrame3 = Color.Aqua;
            }
            else if (thingRandom == 3)
            {
                TextFrame3 = ThingOne.Name;
                TextFrame2 = ThingTwo.Name;
                TextFrame1 = ThingThree.Name;
                TextFrame4 = ThingFour.Name;
                TextFrame5 = ThingFive.Name;
                TextFrame6 = ThingSix.Name;

                IdWordData[2] = IdThing;

                ColorFrame3 = Xamarin.Forms.Color.FromHex("005DFF");
                ColorFrame1 = Color.Violet;
                ColorFrame2 = Xamarin.Forms.Color.FromHex("ADADAD");
                ColorFrame6 = Color.Orange;
                ColorFrame4 = Color.Gold;
                ColorFrame5 = Color.Aqua;
            }
            else if (thingRandom == 4)
            {
                TextFrame4 = ThingOne.Name;
                TextFrame2 = ThingTwo.Name;
                TextFrame3 = ThingThree.Name;
                TextFrame1 = ThingFour.Name;
                TextFrame5 = ThingFive.Name;
                TextFrame6 = ThingSix.Name;

                IdWordData[3] = IdThing;

                ColorFrame4 = Xamarin.Forms.Color.FromHex("005DFF");
                ColorFrame2 = Color.Violet;
                ColorFrame3 = Xamarin.Forms.Color.FromHex("ADADAD"); ;
                ColorFrame1 = Color.Orange;
                ColorFrame5 = Color.Gold;
                ColorFrame6 = Color.Aqua;
            }
            else if (thingRandom == 5)
            {
                TextFrame3 = ThingOne.Name;
                TextFrame5 = ThingTwo.Name;
                TextFrame1 = ThingThree.Name;
                TextFrame2 = ThingFour.Name;
                TextFrame6 = ThingFive.Name;
                TextFrame4 = ThingSix.Name;

                IdWordData[4] = IdThing;

                ColorFrame6 = Xamarin.Forms.Color.FromHex("005DFF");
                ColorFrame2 = Color.Violet;
                ColorFrame1 = Xamarin.Forms.Color.FromHex("ADADAD"); ;
                ColorFrame4 = Color.Orange;
                ColorFrame3 = Color.Gold;
                ColorFrame5 = Color.Aqua;
            }
            else if (thingRandom == 6)
            {
                TextFrame2 = ThingOne.Name;
                TextFrame4 = ThingTwo.Name;
                TextFrame6 = ThingThree.Name;
                TextFrame1 = ThingFour.Name;
                TextFrame3 = ThingFive.Name;
                TextFrame5 = ThingSix.Name;

                IdWordData[5] = IdThing;

                ColorFrame6 = Xamarin.Forms.Color.FromHex("005DFF");
                ColorFrame5 = Color.Violet;
                ColorFrame4 = Xamarin.Forms.Color.FromHex("939034"); ;
                ColorFrame3 = Color.Orange;
                ColorFrame2 = Color.Gold;
                ColorFrame1 = Color.Aqua;
            }
        }

        public async Task<Things> FetchData()
        {
            var query = await _dbContext.Thing.Where(x => x.IdThing == IdThing).FirstOrDefaultAsync();
            return query;
        }

        public async void CheckFrameOne()
        {
            Things result = await FetchData();

            if (result.IdThing == IdWordData[0])
            {
                ColorFrame1 = FrameCorrect();
                Correct = true;
                Points();
                GenerateThingAletory();
                AnswerCorrect();
                ColorDefault();
                await Task.Delay(500);
                GenerateFramesThingAletory();
            }
            else
            {
                ColorFrame1 = FrameInCorrect();
                AnswerInCorrect();
                Correct = false;
                Points();
            }
        }

        public async void CheckFrameTwo()
        {
            Things result = await FetchData();

            if (result.IdThing == IdWordData[1])
            {
                ColorFrame2 = FrameCorrect();
                Correct = true;
                Points();
                GenerateThingAletory();
                AnswerCorrect();
                ColorDefault();
                await Task.Delay(500);
                GenerateFramesThingAletory();
            }
            else
            {
                Correct = false;
                Points();
                ColorFrame2 = FrameInCorrect();
                AnswerInCorrect();
            }
        }

        public async void CheckFrameThree()
        {
            Things result = await FetchData();

            if (result.IdThing == IdWordData[2])
            {
                ColorFrame3 = FrameCorrect();
                Correct = true;
                Points();
                GenerateThingAletory();
                AnswerCorrect();
                ColorDefault();
                await Task.Delay(500);
                GenerateFramesThingAletory();
            }
            else
            {
                Correct = false;
                Points();
                ColorFrame3 = FrameInCorrect();
                AnswerInCorrect();
            }
        }

        public async void CheckFrameFour()
        {
            Things result = await FetchData();

            if (result.IdThing == IdWordData[3])
            {
                Correct = true;
                ColorFrame4 = FrameCorrect();
                Points();
                GenerateThingAletory();
                AnswerCorrect();
                ColorDefault();
                await Task.Delay(500);
                GenerateFramesThingAletory();
            }
            else
            {
                Correct = false;
                ColorFrame4 = FrameInCorrect();
                AnswerInCorrect();
                Points();
            }
        }

        public async void CheckFrameFive()
        {
            Things result = await FetchData();

            if (result.IdThing == IdWordData[4])
            {
                ColorFrame5 = FrameCorrect();
                Correct = true;
                Points();
                GenerateThingAletory();
                AnswerCorrect();
                ColorDefault();
                await Task.Delay(500);
                GenerateFramesThingAletory();
            }
            else
            {
                Correct = false;
                ColorFrame5 = FrameInCorrect();
                AnswerInCorrect();
                Points();
            }
        }

        public async void CheckFrameSix()
        {
            Things result = await FetchData();

            if (result.IdThing == IdWordData[5])
            {
                ColorFrame6 = FrameCorrect();
                Correct = true;
                Points();
                GenerateThingAletory();
                AnswerCorrect();
                ColorDefault();
                await Task.Delay(500);
                GenerateFramesThingAletory();
            }
            else
            {
                Correct = false;
                ColorFrame6 = FrameInCorrect();
                AnswerInCorrect();
                Points();
            }
        }

        public async void ColorDefault()
        {
            await Task.Delay(500);
            ColorFramePrincipal = Xamarin.Forms.Color.FromHex("333333");
        }

        public void AnswerCorrect()
        {
            ColorFramePrincipal = FrameCorrect();
            SoundsApp.SoundCorrect();
        }

        public void AnswerInCorrect()
        {
            ColorFramePrincipal = FrameInCorrect();
            SoundsApp.SoundInCorrect();
        }

        public Color FrameCorrect()
        {
            return Color.GreenYellow;
        }

        public Color FrameInCorrect()
        {
            return Color.Red;
        }

        public void Points()
        {
            if (Correct == true)
            {
                LabelPoints++;
            }
            else
            {
                if (LabelPoints < 1) LabelPoints = 1;
                LabelPoints--;
            }
        }

        public void TimeApp()
        {
            //Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            //{
            //    if (TimeAppMax > 0)
            //    {
            //        TimeAppMax--;
            //        LabelTime = TimeAppMax;
            //    }
            //    else
            //    {
            //        TimeAppMax = 60;
            //        GenerateAnswers();
            //        GenerateNumber();
            //        Points();
            //        AnswerIncCorrect();
            //        ColorDefault();
            //        return false;
            //    }
            //    return true;
            //});
        }

        public async Task GoPageInfo()
        {
            //if (ValidationInternet.IsConnected())
            //{
            //    ShowInterstical();
            //    if (CrossMTAdmob.Current.IsInterstitialLoaded())
            //    {
            //        CrossMTAdmob.Current.ShowInterstitial();
            //        await Navigation.PushAsync(new Page_Info());
            //    }
            //}
            await Navigation.PushAsync(new Page_Info());
        }

        public void ShowInterstical()
        {
            var idIntersticial = "ca-app-pub-7633493507240683/7190362096";

            CrossMTAdmob.Current.LoadInterstitial(idIntersticial);
        }

        public void Theme()
        {
            ThemeApp = LocalStorange.GetLocalStorange("theme");

            if (ThemeApp == "Dark")
            {
                Thema = Xamarin.Forms.Color.FromHex("#000000");
                ImageTheme = ImageSource.FromFile("light.png");
                LocalStorange.SetLocalStorange("theme", "Light");
            }
            else
            {
                Thema = Xamarin.Forms.Color.FromHex("303345");
                ImageTheme = ImageSource.FromFile("dark.png");
                LocalStorange.SetLocalStorange("theme", "Dark");
            }
        }

        #endregion Methods

        #region Commands

        public ICommand bntCkeckCommandOne => new Command(CheckFrameOne);

        public ICommand bntCkeckCommandTwo => new Command(CheckFrameTwo);
        public ICommand bntCkeckCommandThree => new Command(CheckFrameThree);
        public ICommand bntCkeckCommandFour => new Command(CheckFrameFour);
        public ICommand bntCkeckCommandFive => new Command(CheckFrameFive);
        public ICommand bntCkeckCommandSix => new Command(CheckFrameSix);
        public ICommand bntGoPageInfoCommand => new Command(async () => await GoPageInfo());
        public ICommand bntThemeCommand => new Command(Theme);

        #endregion Commands
    }
}