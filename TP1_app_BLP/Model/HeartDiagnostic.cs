using CsvHelper.Configuration.Attributes;

namespace TP01_HeartDiseaseDiagnostic
{
    public class HeartDiagnostic
    {
        [Name("cp")]
        public double ChestPain { get; set; }
        public double NormalizedChestPain => ChestPain / 3.0;
        [Name("thal")]
        public double Thalassemia { get; set; }
        public double NormalizedThalassemia => (Thalassemia - 1) / 2.0;
        [Name("oldpeak")]
        public double OldPeak { get; set; }
        public double NormalizedOldPeak => OldPeak / 6.2;
        [Name("ca")]
        public double Fluoroscopy { get; set; }
        public double NormalizedFluoroscopy => Fluoroscopy / 3.0;
        [Name("target")]
        public double Diagnostic { get; set; }
    }
}