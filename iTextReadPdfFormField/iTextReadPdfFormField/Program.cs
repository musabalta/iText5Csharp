using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Linq;

namespace iTextReadPdfFormField
{
    class Program
    {
        private static string GetFormFieldNames(PdfReader pdfReader)
        {
            return string.Join("\r\n", pdfReader.AcroFields.Fields.Select(x => x.Key).ToArray()); // return Field Name List
        }

        static void Main(string[] args)
        {
            string inputFile = "PdfDocument.pdf";

            PdfReader pdfReader = new PdfReader(inputFile);

            PdfReader.unethicalreading = true;

            string outputFile = "OutputPdfFile.pdf";

            PdfStamper pdfStamp = new PdfStamper(pdfReader, new FileStream(outputFile, FileMode.Create));

            AcroFields fields = pdfStamp.AcroFields;

            fields.SetField("Field Name", "Input Value"); // If you do not know *field name*, you can run *GetFormFieldNames(pdfReader)* function to learn

            pdfStamp.Close();

            pdfReader.Close();
        }
    }
}
