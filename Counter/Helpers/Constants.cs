namespace Counter.Helpers
{
    public static class Constants
    {
        // Ścieżka do pliku z zapisanymi licznikami
        public const string CounterDataFilePath = "counters.json";

        // Klucz i wektor inicjalizacji dla szyfrowania AES
        public const string EncryptionKey = "JCBIXYXDnc4cIF8j"; // Klucz musi być 16 bajtów (128 bitów)
        public const string EncryptionIV = "1emfeXKevmStDiH4";   // IV musi być 16 bajtów (128 bitów)

        // Inne stałe używane w aplikacji (można dodawać według potrzeb)
        public const string DefaultCounterColor = "#000000"; // Domyślny kolor liczników
    }
}
