﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vdivsvirus.Interfaces;
using vdivsvirus.Types;

namespace vdivsvirus.Services
{
    public class DataSetService : IRequestDataSet, ISendSymptome
{

        public DataSetService()
        {

        }

        public bool DataSetAvailable()
        {
            return true;
        }

        public List<SymptomeType> GetSymptomeInternals()
        {
            return new List<SymptomeType>()
            {
                new SymptomeType{ IdentData = new SymptomeIdentData() { id = 1, inputType = SymptomeInputType.slider, desc = "", name = "Fieber", settings="min=36.5;max=42.5;step=0.1" }, symptomePropability = (float)87.9, ScaleFunc = input => input * 1000 } ,
                new SymptomeType{ IdentData = new SymptomeIdentData() { id = 2, inputType = SymptomeInputType.slider, desc = "", name = "Husten", settings="min=0;max=100;step=1" }, symptomePropability = (float)67.7 },
                new SymptomeType{ IdentData = new SymptomeIdentData() { id = 3, inputType = SymptomeInputType.slider, desc = "", name = "Abgeschlagenheit", settings="min=0;max=100;step=1" }, symptomePropability = (float)38.1 },
                new SymptomeType{ IdentData = new SymptomeIdentData() { id = 4,inputType = SymptomeInputType.slider, desc = "", name = "Kurzatmigkeit", settings="min=0;max=100;step=1" }, symptomePropability = (float)18.6 },
                new SymptomeType{ IdentData = new SymptomeIdentData() { id = 5, inputType = SymptomeInputType.slider, desc = "", name = "Muskel-/Gelenkschmerz", settings="min=0;max=100;step=1" }, symptomePropability = (float)14.8},
                new SymptomeType{ IdentData = new SymptomeIdentData() { id = 6, inputType = SymptomeInputType.slider, desc = "", name = "Halsschmerz", settings="min=0;max=100;step=1" } , symptomePropability = (float)13.9},
                new SymptomeType{ IdentData = new SymptomeIdentData() { id = 7, inputType = SymptomeInputType.slider, desc = "", name = "Kopfschmerz", settings="min=0;max=100;step=1" }, symptomePropability = (float)13.6 },
                new SymptomeType{ IdentData = new SymptomeIdentData() { id = 8, inputType = SymptomeInputType.slider, desc = "", name = "Schüttelfrost", settings="min=0;max=100;step=1" }, symptomePropability = (float)11.4 },
                new SymptomeType{ IdentData = new SymptomeIdentData() { id = 9, inputType = SymptomeInputType.slider, desc = "", name = "Übelkeit", settings="min=0;max=100;step=1" } , symptomePropability = (float)5.0},
                new SymptomeType{ IdentData = new SymptomeIdentData() { id = 10, inputType = SymptomeInputType.slider, desc = "", name = "Verstopfte Nase", settings="min=0;max=100;step=1" } , symptomePropability = (float)4.8},
                new SymptomeType{ IdentData = new SymptomeIdentData() { id = 11, inputType = SymptomeInputType.slider, desc = "", name = "Durchfall", settings="min=0;max=100;step=1" } , symptomePropability = (float)3.7},
            };

        }

        public List<SymptomeType> GetSymptomeTypes()
        {
            return GetSymptomeInternals();//.Select(item => item.DisplayData).ToList();
        }

        public bool HistorySetAvailable()
        {
            throw new NotImplementedException();
        }

        public SymptomeDataSet RequestDataSet()
        {
            return new SymptomeDataSet() 
            { userID = Guid.NewGuid(), 
              time = DateTime.Now, 
              symptomes = new Dictionary<int, float>() 
              { 
                  [1] = 70f,
                  [2] = 80f,
                  [3] = 60f,
                  [4] = 30f,
                  [5] = 40f,
                  [6] = 30f,
                  [7] = 20f,
                  [8] = 70f,
                  [9] = 0f,
                  [10] = 40f,
                  [11] = 0f,
              },

            };
        }

        public PropabilityDataSet RequestDiseasePropability(Guid userID, DateTime time)
        {
            return new PropabilityDataSet()
            {
                userID = userID,
                time = time,
                propabilities = new Dictionary<int, float>()
                {
                    [1] = 20
                }
            };
        }

        public PropabilityHistorySet RequestDiseasePropabilityHistory(Guid userID)
        {
            throw new NotImplementedException();
        }

        public PropabilityHistorySet RequestHistorySet()
        {
            throw new NotImplementedException();
        }

        public void SendDataResultSet(PropabilityDataSet data)
        {
            throw new NotImplementedException();
        }

        public void SendDiseaseDataSet(DiseaseDataSet data)
        {
            System.Diagnostics.Trace.Write(data);
        }

        public void SendHistoryResultSet(PropabilityDataSet data)
        {
            throw new NotImplementedException();
        }

        public void SendSymptomeDataSet(SymptomeInputDataSet data)
        {
            System.Diagnostics.Trace.Write(data);
        }
    }







}
