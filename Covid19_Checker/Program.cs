using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            var mlContext = new MLContext();
            var trainingDataView = mlContext.Data.LoadFromTextFile<Model.Covid>("dataset/trainingdataset.csv", hasHeader: true, separatorChar: ',');
            var testDataView = mlContext.Data.LoadFromTextFile<Model.Covid>("dataset/testdataset.csv", hasHeader: true, separatorChar: ',');

            var pipeline = mlContext.Transforms.Concatenate("Features", new string[] { "BreathingProblem","Fever","DryCough","SoreThroat","RunningNose","Asthma","ChronicLungDisease","HeadAche",
     "HeartDisease","Diabetes","HyperTension","Fatigue","Gastrointestinal","AbroadTravel","ContactWithCovid","AttendedLargeGathering",
     "VisitedPublicExposed","FamilyWorkingsInPublic","WearingMasks","SanitizationFromMarket" })
                .Append(mlContext.BinaryClassification.Trainers.SgdCalibrated(labelColumnName: "Label", featureColumnName: "Features"));

            var model = pipeline.Fit(trainingDataView);

            //lets test it
            var predicts = model.Transform(testDataView);
            var metrics = mlContext.BinaryClassification.Evaluate(predicts, labelColumnName: "Label", scoreColumnName: "Score");

            mlContext.Model.Save(model, trainingDataView.Schema, "CovidModel.zip");

            PredictionEngine<Model.Covid, Model.CovidPrediction> predictionEngine = mlContext.Model.CreatePredictionEngine<Model.Covid, Model.CovidPrediction>(model, trainingDataView.Schema);

            var prediction = predictionEngine.Predict(new Model.Covid()
            {
                AbroadTravel = 1,
                Asthma = 1,
                AttendedLargeGathering = 1,
                BreathingProblem = 1,
                ChronicLungDisease = 1,
                ContactWithCovid = 1,
                Diabetes = 1,
                FamilyWorkingsInPublic = 1,
                DryCough = 1,
                Fatigue = 1,
                Fever = 1,
                Gastrointestinal = 0,
                HeadAche = 0,
                HeartDisease = 0,
                HyperTension = 0,
                RunningNose = 0,
                SanitizationFromMarket = 0,
                SoreThroat = 0,
                VisitedPublicExposed = 0,
                WearingMasks = 0
            });
            Console.WriteLine("Covid olup olmadığınız yönündeki tahminimiz:" + prediction.Prediction);
        }
    }
}
