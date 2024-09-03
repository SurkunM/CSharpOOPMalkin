using System.Text;

namespace CSVTask;

internal class CSVMain
{
    public static void ConvertingCSV(string inputFile, string outputFile)
    {
        try
        {
            using StreamReader reader = new StreamReader(inputFile);
            using StreamWriter writer = new StreamWriter(outputFile);

            char common = ',';
            char quotes = '\"';
            bool open = false;

            string? currentLine;

            writer.WriteLine("<table>");

            while ((currentLine = reader.ReadLine()) != null)
            {
                StringBuilder stringBuilder = new StringBuilder();

                currentLine = currentLine.Replace("&", "&amp").Replace(">", "&gt").Replace("<", "&lt");

                if (!open)
                {
                    stringBuilder.AppendLine("\t<tr>");
                }

                bool isNewCell = true;

                for (int i = 0; i < currentLine.Length; i++)
                {
                    if (!open)
                    {
                        if (currentLine[i] == common)
                        {
                            stringBuilder.AppendLine("</td>");
                            isNewCell = true;
                        }
                        else if (isNewCell)
                        {
                            if (currentLine[i] == quotes)
                            {
                                open = true;
                                stringBuilder.Append("\t\t<td>");
                            }
                            else
                            {
                                stringBuilder.Append($"\t\t<td>{currentLine[i]}");
                            }

                            isNewCell = false;
                        }
                        else
                        {
                            stringBuilder.Append(currentLine[i]);

                            if (i == currentLine.Length - 1)
                            {
                                stringBuilder.AppendLine("</td>");
                            }
                        }
                    }
                    else
                    {
                        if (currentLine[i] == quotes)
                        {
                            if (i + 1 < currentLine.Length && currentLine[i + 1] == quotes)
                            {
                                stringBuilder.Append(quotes);
                                i++;
                            }
                            else
                            {
                                open = false;

                                if (i == currentLine.Length - 1)
                                {
                                    stringBuilder.AppendLine("</td>");
                                }
                            }
                        }
                        else
                        {
                            stringBuilder.Append(currentLine[i]);
                        }
                    }
                }

                if (open)
                {
                    stringBuilder.Append("<br/>");
                }
                else
                {
                    stringBuilder.AppendLine("\t</tr>");
                }

                writer.Write(stringBuilder.ToString());
            }

            writer.Write("</table>");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден");
        }
    }

    static void Main(string[] args)
    {
        ConvertingCSV("..\\..\\..\\File\\innerText.txt", "..\\..\\..\\File\\outText.txt");
    }
}