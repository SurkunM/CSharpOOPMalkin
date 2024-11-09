namespace CsvTask;

internal class CsvMain
{
    public static void ConvertTextToCsv(string inputFile, string outputFile)
    {
        using StreamReader reader = new StreamReader(inputFile);
        using StreamWriter writer = new StreamWriter(outputFile);

        const char comma = ',';
        const char quote = '\"';
        const string doubleTabulation = "\t\t";

        string title = "HTML file";
        // string fileName = "Csv task";
        // string content = "Table";
        string charset = "UTF-8";

        bool isQuotesOpen = false;
        string? currentLine;

        writer.WriteLine("<!DOCTYPE HTML>");
        writer.WriteLine("<html>");
        writer.WriteLine("\t<head>");

        writer.WriteLine($"{doubleTabulation}<meta charset=\"{charset}\">");

        writer.Write($"{doubleTabulation}<title>");
        writer.Write(title);
        writer.WriteLine("</title>");

        // writer.WriteLine($"{doubleTabulation}<meta name=\"{fileName}\" content=\"{content}\">");

        writer.WriteLine("\t</head>");
        writer.WriteLine("\t<body>");
        writer.WriteLine($"{doubleTabulation}<table>");

        while ((currentLine = reader.ReadLine()) != null)
        {
            if (!isQuotesOpen)
            {
                writer.WriteLine($"{doubleTabulation}\t<tr>");
            }

            bool isNewCell = true;

            for (int i = 0; i < currentLine.Length; i++)
            {
                if (currentLine[i] == '&')
                {
                    writer.Write("&amp;");
                }
                else if (currentLine[i] == '<')
                {
                    writer.Write("&lt;");
                }
                else if (currentLine[i] == '>')
                {
                    writer.Write("&gt;");
                }
                else if (!isQuotesOpen)
                {
                    if (currentLine[i] == comma)
                    {
                        writer.WriteLine("</td>");
                        isNewCell = true;
                    }
                    else if (isNewCell)
                    {
                        if (currentLine[i] == quote)
                        {
                            writer.Write($"{doubleTabulation}{doubleTabulation}<td>");
                            isQuotesOpen = true;
                        }
                        else
                        {
                            writer.Write($"{doubleTabulation}{doubleTabulation}<td>{currentLine[i]}");
                        }

                        isNewCell = false;
                    }
                    else
                    {
                        writer.Write(currentLine[i]);

                        if (i == currentLine.Length - 1)
                        {
                            writer.WriteLine("</td>");
                        }
                    }
                }
                else
                {
                    if (currentLine[i] == quote)
                    {
                        if (i + 1 < currentLine.Length && currentLine[i + 1] == quote)
                        {
                            writer.Write(quote);
                            i++;
                        }
                        else
                        {
                            isQuotesOpen = false;

                            if (i == currentLine.Length - 1)
                            {
                                writer.WriteLine("</td>");
                            }
                        }
                    }
                    else
                    {
                        writer.Write(currentLine[i]);
                    }
                }
            }

            if (isQuotesOpen)
            {
                writer.Write("<br/>");
            }
            else
            {
                writer.WriteLine($"{doubleTabulation}\t</tr>");
            }
        }

        writer.WriteLine($"{doubleTabulation}</table>");
        writer.WriteLine("\t</body>");
        writer.Write("</html>");
    }

    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
            {
                Console.WriteLine("File patch was not found");
            }
            else
            {
                ConvertTextToCsv(args[0], args[1]);
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Не найдены пути к файлу для чтения или записи");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Не найден файл для чтения");
        }
    }
}