using Fructika.Extensions;
using Fructika.Helpers;
using Fructika.Models;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Fructika.ViewModels
{
    public class FoodViewModel : BaseViewModel
    {
        Food Food { get; set; }
        new string Title { get; set; }

        public ObservableCollection<ChartDataPoint> SugarsChartData { get; set; }
        public ObservableCollection<ChartDataPoint> FructoseGlucoseChartData { get; set; }

        public ChartColorCollection FructoseGlucoseChartColors => new ChartColorCollection
        {
            FructoseColour,
            GlucoseColour
        };

        public ChartColorCollection SugarsChartColors => new ChartColorCollection
        {
            FructoseColour,
            GlucoseColour,
            MaltoseColour,
            SucroseColour
        };

        public Color FructoseLevelColour => Food.Fructose.GetValueOrDefault() < AppPreferences.FructoseWarningLevel
            ? GetColor("PrimaryDarkColor") : GetColor("SecondaryColor");
        public Color GlucoseColour => GetColor("GlucoseColor");
        public Color FructoseColour => GetColor("FructoseColor");
        public Color MaltoseColour => GetColor("MaltoseColor");
        public Color SucroseColour => GetColor("SucroseColor");

        public string Description => Food.Description;
        public string Group => Food.FoodGroup;
        public string TotalSugars => Food.TotalSugars.GetGrams();
        public string Glucose => Food.Glucose.GetGrams();
        public string Fructose => Food.Fructose.GetGrams();
        public string Maltose => Food.Maltose.GetGrams();
        public string Sucrose => Food.Sucrose.GetGrams();
        public string Lactose => Food.Lactose.GetGrams();
        public string DietaryFiber => Food.DietaryFiber.GetGrams();
        public string Protein => Food.Protein.GetGrams();
        public string Image => ""; // FoodDataStore.GetFoodGroup(Food.FoodGroup)?.Image; 
        public string Icon => ""; // FoodDataStore.GetFoodGroup(Food.FoodGroup)?.Icon; 

        public FoodViewModel(Food food)
        {
            Food = food;

            SugarsChartData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint("Fructose", (double)Food.Fructose.GetValueOrDefault(0)),
                new ChartDataPoint("Glucose", (double)Food.Glucose.GetValueOrDefault(0)),
                new ChartDataPoint("Maltose", (double)Food.Maltose.GetValueOrDefault(0)),
                new ChartDataPoint("Sucrose", (double)Food.Sucrose.GetValueOrDefault(0))
            };

            FructoseGlucoseChartData = new ObservableCollection<ChartDataPoint>
            {
                new ChartDataPoint(Fructose, (double)Food.Fructose.GetValueOrDefault(0)),
                new ChartDataPoint(Glucose, (double)Food.Glucose.GetValueOrDefault(0))
            };
        }

        public static Color GetColor(string key)
        {
            return (Color)Application.Current.Resources[key];
        }
    }
}
