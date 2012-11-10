using System;
using System.Drawing;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;

namespace EmguCVSimpleProject
{
    class Program
    {
        static void Main()
        {
            try
            {
                string resourcePath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;

                Console.Write("Insert images resource path: ");
                string imagesResourcePath = Console.ReadLine();
                string[] imagesFileNames = Directory.GetFiles(imagesResourcePath);
                
                if (!Directory.Exists(imagesResourcePath + "_faces"))
                    Directory.CreateDirectory(imagesResourcePath + "_faces");

                CascadeClassifier cascadeClassifier = new CascadeClassifier(resourcePath + @"\haarcascade_frontalface_default.xml");
                Rectangle[] detectedFaceRectangles;

                int counter = 0;
                int totalCount = imagesFileNames.Length;
                foreach (string imageName in imagesFileNames)
                {
                    try
                    {
                        counter++;
                        Console.WriteLine("Processing image " + counter + " of " + totalCount);

                        Image<Bgr, Byte> img = new Image<Bgr, byte>(imageName);
                        Image<Gray, Byte> grayFrame = img.Convert<Gray, Byte>();
                        detectedFaceRectangles = cascadeClassifier.DetectMultiScale(grayFrame, 1.1, 1, Size.Empty, Size.Empty);
                        if (detectedFaceRectangles.Length > 0)
                        {
                            img = img.GetSubRect(detectedFaceRectangles[0]);
                           // Console.WriteLine(imageName + " has face detected.");
                            int lastSlash = imageName.LastIndexOf('\\');
                            string fileName = imageName.Substring(lastSlash + 1, imageName.Length - lastSlash - 1);
                            img.Save(imagesResourcePath + "_faces/" + fileName);
                        }
                        else
                        {
                            Console.WriteLine(imageName + " has no face detected.");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(imageName + ": " + e.Message);
                        Console.ReadLine();
                    }
                }

                Console.WriteLine("Finished processing. Enter to exit.");
                Console.ReadLine();

                //SEPARATE PROJECT

                // String win1 = "Test Window"; //The name of the window
                // CvInvoke.cvNamedWindow(win1); //Create the window using the specific name
                // Image<Bgr, Byte> img = new Image<Bgr, byte>(resourcePath + @"\testFaceDetection.jpg");
                // Image<Gray, Byte> grayFrame = img.Convert<Gray, Byte>();

                // //HaarCascade haarCascade = new HaarCascade(resourcePath+@"\haarcascade_frontalface_default.xml");//OBSOLETE
                // //var detectedFaces = grayFrame.DetectHaarCascade(haarCascade)[0]; //OBSOLETE
                // ////MCvAvgComp[] detectedFaces2 = haarCascade.Detect(grayFrame); // OBSOLETE
                // //foreach (MCvAvgComp face in detectedFaces2)
                // //    img.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);

                // CascadeClassifier cascadeClassifier = new CascadeClassifier(resourcePath + @"\haarcascade_frontalface_default.xml");
                // Rectangle[] detectedFaceRectangles = cascadeClassifier.DetectMultiScale(grayFrame, 1.1, 1, Size.Empty, Size.Empty);
                // foreach (Rectangle rectangle in detectedFaceRectangles)
                // {
                //     img.Draw(rectangle, new Bgr(0, 1, 0), 2);
                // }



                // // extracts rectangle and saves it out
                // //Image<Bgr, Byte> imgFace1 = new Image<Bgr, byte>(detectedFaceRectangles[0].Width, detectedFaceRectangles[0].Height);
                // //imgFace1 = img.GetSubRect(detectedFaceRectangles[0]);
                //// imgFace1.Save(resourcePath + @"\extractedFace.jpg");


                // //imgFace1.ToBitmap().Save(resourcePath + @"\extractedFace.png", ImageFormat.Png);

                // CvInvoke.cvShowImage(win1, img); //Show the image
                // CvInvoke.cvWaitKey(0); //Wait for the key pressing event
                // CvInvoke.cvDestroyWindow(win1); //Destory the window
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.ReadLine();
            }
        }
    }
}
