using System;
using System.Collections.Generic;

namespace vdivsvirus.Types
{




    #region Symptome Data Set Data Types

    /// <summary>
    /// Symptome Input Type Enumeration
    /// </summary>
    public enum SymptomeInputType
    {
        /// <summary>
        /// Not displayed - hidden filed
        /// </summary>
        none = 0,

        /// <summary>
        /// YesNoQuestion
        /// </summary>
        yesno = 1,

        /// <summary>
        /// Slider Value
        /// settingString = min=x;max=y;stepz
        /// </summary>
        slider = 2,

        /// <summary>
        /// Enumeration List
        /// settingString = key1=value1;key2=value2;...
        /// </summary>
        list = 3
    }

    /// <summary>
    /// Symptome Type Information
    /// (all data)
    /// </summary>
    public class SymptomeType
    {
        public SymptomeType()
        {
            //Default Scale Func is Input == Output -> 1:1 Mapping
            ScaleFunc = input => input;
        }

        /// <summary>
        /// Symptome Ident Data
        /// (will be sent to app)
        /// </summary>
        public SymptomeIdentData IdentData { get; set; }

        /// <summary>
        /// Symptome Propability Factor 
        /// Setting for Proability Data Analysis 
        /// </summary>
        public float symptomePropability { get; set; }

        /// <summary>
        /// Threshold Propability Factor 
        /// Setting for Get Recommendation Analysis 
        /// </summary>
        public float thresholdFactor { get; set; }

        /// <summary>
        /// Scaling Function for mapping of input value
        /// to propability scale
        /// </summary>
        public Func<float, float> ScaleFunc { get; set; }
    }

    /// <summary>
    /// Symptome Display Data
    /// (display only information)
    /// </summary>
    public class SymptomeIdentData
    {

        /// <summary>
        /// Symptome Identifier
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Symptome Input Classifier
        /// </summary>
        public SymptomeInputType inputType { get; set; }

        /// <summary>
        /// Symptome Display Type
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Symptome Display Description
        /// </summary>
        public string desc { get; set; }

        /// <summary>
        /// Symptome Input Settings 
        /// </summary>
        public string settings { get; set; }
    }


    /// <summary>
    /// Symptome Input Data
    /// (feedback from app)
    /// </summary>
    public class SymptomeInputData
    {
        /// <summary>
        /// Symptome ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Symptome Strength
        /// </summary>
        public float strength { get; set; }
    }

    /**
     * GeoData
     * https://developer.android.com/reference/android/location/Location.html
     */
    public class GeoData
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public Int64 time { get; set; } //milliseconds since 1.1.1970 (UTC)
        public double accuracy { get; set; }
    }

    /// <summary>
    /// Symptome Input Data Set
    /// </summary>
    public class SymptomeInputDataSet
    {
        /// <summary>
        /// Anonymized User ID
        /// </summary>
        public Guid userID { get; set; }

        /// <summary>
        /// Symptome Inputs
        /// </summary>
        public List<SymptomeInputData> symptomes { get; set; }

        /// <summary>
        /// Moving Profile Data
        /// </summary>
        public List<GeoData> geodata { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime time { get; set; }
    }


    public class UserDataRef
    {
        /// <summary>
        /// Anonymized User ID
        /// </summary>
        public Guid userID { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime time { get; set; }
    }



    #endregion


    #region Disease Data Set Data Types

    public class DiseaseData
    {
        /// <summary>
        /// Disease Identifier
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Disease Propability Finding
        /// </summary>
        public float propability { get; set; }
    }

    public class DiseaseAcknowledgement
    {
        /// <summary>
        /// Disease Identifier
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Acknowledged Disease Finding
        /// </summary>
        public bool acknowledged { get; set; }
    }


    /// <summary>
    /// Identification Information 
    /// about Diseases
    /// </summary>
    public class DiseaseIdentData
    {

        /// <summary>
        /// Disease Identifier
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Disease Display Type
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Disease Display Description
        /// </summary>
        public string desc { get; set; }

        /// <summary>
        /// Disease Information Link 
        /// </summary>
        public string infoLink { get; set; }
    }

    /// <summary>
    /// Disease Type with Ident and Internal Data
    /// </summary>
    public class DiseaseType
    {
        /// <summary>
        /// Disease Ident Data
        /// </summary>
        public DiseaseIdentData IdentData { get; set; }

        /// <summary>
        /// Returns a recommendation message
        /// based on the propability values from the
        /// analysis.
        /// </summary>
        public Func<float, string> GetRecommendation { get; set; }

        /// <summary>
        /// Returns the function to calculate the propability
        /// based on the given symptome data set.
        /// </summary>
        public Func<SymptomeDataSet, float> propabilityAlgorithm { get; set; }
    }

    /**
     * Structs of AuthenticationData
     */
    public class AuthenticationData
    {
        public string userName { get; set; } //User Name of the to authenticate Person                 
        public string hashedPwd { get; set; } //User Password in a hashed format of the to authenticate Person
    }

    /**
     * Structs of DiseaseAcknowledgeSet
     */
    public class DiseaseAcknowledgeSet
    {
        public Guid userID { get; set; }
        public string diseaseID { get; set; }
        public bool testResult { get; set; }
        public AuthenticationData authenticator { get; set; }
        public DateTime time { get; set; } //milliseconds since 1.1.1970 (UTC)
    }

    #endregion

    #region PDA

    /**
     * Structs of SymptomeDataSet [INPUT]
     */
    public class SymptomeDataSet
    {
        public Guid userID { get; set; }
        public DateTime time { get; set; }
        public List<SymptomeInputData> symptomes { get; set; }
    }

    /**
     * Structs of PropabilityDataSet [OUTPUT]
     */
    public class PropabilityDataSet
    {
        public Guid userID { get; set; }
        public DateTime time { get; set; }
        public List<DiseaseData> propabilities { get; set; }
    }

    #endregion


    #region PGA

    // Propabilistic Gradient Analysis (PGA)
    // (Disease Pattern Early Recoginition)

    /**
     * Structs of PropabilityHistorySet [INPUT]
     */
    public class PropabilityHistorySet
    {
        public Guid userID { get; set; }
        public List<PropabilityDataSet> history { get; set; }
    }

    #endregion

    #region Response Data Set Data Types


    /**
     * Structs of ResponseDataSet 
     */
    public class UserResponseDataSet
    {
        public Guid userID { get; set; }
        public DateTime time { get; set; }
        public List<DiseaseData> propabilities { get; set; }
        public List<DiseaseIdentData> diseaseTypes { get; set; }
        public string message { get; set; }
    }

    /**
     * Structs of UserHistoryDataSet 
     */
    public class UserHistoryDataSet
    {
        public Guid userID { get; set; }
        public List<PropabilityDataSet> history { get; set; }
        public Dictionary<int, DiseaseType> diseaseTypes { get; set; }
        public string message { get; set; }
    }

    #endregion
}