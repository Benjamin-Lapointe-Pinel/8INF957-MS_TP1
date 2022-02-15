namespace TP01_HeartDiseaseDiagnostic
{
    public class HeartDiagnostic
    {
        public uint ChestPain { get; private set; }
        public double NormalizedChestPain => ChestPain / 3.0;
        public uint Thalassemia { get; private set; }
        public double NormalizedThalassemia => (Thalassemia - 1) / 2.0;
        public float OldPeak { get; private set; }
        public double NormalizedOldPeak => OldPeak / 6.2;
        public uint Fluoroscopy { get; private set; }
        public double NormalizedFluoroscopy => Fluoroscopy / 3.0;
        public uint Diagnostic { get; private set; }
    }
}