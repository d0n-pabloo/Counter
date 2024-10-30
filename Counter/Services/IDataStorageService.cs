﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Services
{
    public interface IDataStorageService
    {
        void SaveData(string encryptedData);  // Zapisuje zaszyfrowane dane
        string LoadData();                    // Ładuje zaszyfrowane dane
        string SerializeData(List<Models.Counter> counters); // Serializuje listę liczników do JSON
        List<Models.Counter> DeserializeData(string jsonData); // Deserializuje JSON na listę liczników
    }
