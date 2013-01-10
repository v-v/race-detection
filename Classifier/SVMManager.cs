using Emgu.CV;
using Emgu.CV.ML;
using Emgu.CV.Structure;

namespace Classifier
{
    public class SVMManager
    {
        private const string IME_DATOTEKE = "SVM-klasifikacija-rasa.svm";

        public static void Ucenje(Matrix<float> featuriSlika, Matrix<float> klaseSlika)
        {
            using (var model = new SVM())
            {
                var p = new SVMParams
                            {
                                KernelType = Emgu.CV.ML.MlEnum.SVM_KERNEL_TYPE.LINEAR,
                                SVMType = Emgu.CV.ML.MlEnum.SVM_TYPE.C_SVC,
                                C = 1,
                                TermCrit = new MCvTermCriteria(100, 0.00001)
                            };

                model.TrainAuto(featuriSlika, klaseSlika, null, null, p.MCvSVMParams, 5);
                model.Save(IME_DATOTEKE);
            }
        }

        public static float Predikcija(Matrix<float> featuriSlike)
        {
            using (var model = new SVM())
            {
                var p = new SVMParams
                            {
                                KernelType = Emgu.CV.ML.MlEnum.SVM_KERNEL_TYPE.LINEAR,
                                SVMType = Emgu.CV.ML.MlEnum.SVM_TYPE.C_SVC,
                                C = 1,
                                TermCrit = new MCvTermCriteria(100, 0.00001)
                            };

                model.Load(IME_DATOTEKE);

                return model.Predict(featuriSlike);
            }
        }
    }
}
