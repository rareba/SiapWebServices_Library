namespace SiapWebServices_Library
{
    public class Utility
    {
        // Generate Supplier code string
        public static string Generate_Supplier_Code_String(int codice = 0, int sottoconto = 1, int conto = 1, string mastro = "30")
        {
            codice++;

            string string_conto = " ";
            string string_sottoconto = " ";
            string string_codice = "     ";

            if (conto > 9)
            {
                string_conto = "";
            }

            if (sottoconto > 9)
            {
                string_sottoconto = "";
            }

            if (codice > 9)
            {
                string_codice = "    ";
            }
            else if (codice > 99)
            {
                string_codice = "   ";
            }
            else if (codice > 999)
            {
                string_codice = "  ";
            }
            else if (codice > 9999)
            {
                string_codice = "  ";
            }
            else if (codice > 99999)
            {
                string_codice = " ";
            }
            else if (codice >= 999999)
            {
                string_codice = "";
            }

            string customercode = mastro + string_conto + conto + string_sottoconto + sottoconto + string_codice + codice;

            return customercode;
        }

    }

  
}
