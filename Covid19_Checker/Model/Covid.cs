using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Checker.Model
{
    class Covid
    {

        [LoadColumn(0)]        
        public float BreathingProblem { get; set; }
        [LoadColumn(1)]
        public float Fever { get; set; }
        [LoadColumn(2)]
        public float DryCough { get; set; }
        [LoadColumn(3)]
        public float SoreThroat { get; set; }
        [LoadColumn(4)]
        public float RunningNose { get; set; }
        [LoadColumn(5)]
        public float Asthma { get; set; }
        [LoadColumn(6)]
        public float ChronicLungDisease { get; set; }
        [LoadColumn(7)]
        public float HeadAche { get; set; }
        [LoadColumn(8)]
        public float HeartDisease { get; set; }
     
        [LoadColumn(9)]
        public float Diabetes { get; set; }
        [LoadColumn(10)]
        public float HyperTension { get; set; }
        [LoadColumn(11)]
        public float Fatigue { get; set; }
        [LoadColumn(12)]
        public float Gastrointestinal { get; set; }
        [LoadColumn(13)]
        public float AbroadTravel { get; set; }
        [LoadColumn(14)]
        public float ContactWithCovid { get; set; }
        [LoadColumn(15)]
        public float AttendedLargeGathering { get; set; }
        [LoadColumn(16)]
        public float VisitedPublicExposed { get; set; }
        [LoadColumn(17)]
        public float FamilyWorkingsInPublic { get; set; }
        [LoadColumn(18)]
        public float WearingMasks { get; set; }
        [LoadColumn(19)]
        public float SanitizationFromMarket { get; set; }
        [LoadColumn(20)]
        public bool Label { get; set; }
  
    }
}
