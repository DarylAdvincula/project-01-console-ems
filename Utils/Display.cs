namespace ConsoleEMS.Utils;

public class Table
{
    public char SideX { get; set; } = '┃';
    public char SideY { get; set; } = '━';
    public char VertexTop { get; set; } = '┳';
    public char VertexRight { get; set; } = '┫';
    public char VertexBottom { get; set; } = '┻';
    public char VertexLeft { get; set; } = '┣';
    public char VertexMiddle { get; set; } = '╋';
    public char VertexTopLeft { get; set; } = '┏';
    public char VertexTopRight { get; set; } = '┓';
    public char VertexBottomLeft { get; set; } = '┗';
    public char VertexBottomRight { get; set; } = '┛';
    public List<Column> Columns { get; set; } = [];
    public List<Row> Rows { get; set; } = [];

    private Table() {}

    public static Table Build()
    {
        return new Table();
    }

    public Table SetColumns(List<Column> columns)
    {
        Columns = columns;
        return this;
    }

    public Table SetRows(List<Row> rows)
    {
        Rows = rows;
        return this;
    }

    public Table WithSides(char x, char y)
    {
        SideX = x;
        SideY = y;
        return this;
    }

    public Table WithVertices(
        char left,
        char top, 
        char right,
        char bottom,
        char topLeft,
        char topRight,
        char bottomLeft,
        char bottomRight,
        char middle
    )
    {
        VertexTop = top;
        VertexRight = right;
        VertexBottom = bottom;
        VertexLeft = left;
        VertexTopLeft = topLeft;
        VertexTopRight = topRight;
        VertexBottomLeft = bottomLeft;
        VertexBottomRight = bottomRight;
        VertexMiddle = middle;
        return this;
    }

    public void Display()
    {
        Column.Display(this);
        Row.DisplayAll(this);
    }
}

public class Column
{
    public string Name;
    public int Width;

    public Column(string name, int? width = null)
    {
        Name = name;
        Width = width ?? name.Length;
    }

    private static string GenerateTopBorder(Table table)
    {
        var index = 0;
        var result = string.Empty;
        var columns = table.Columns;
        var maxIndex = table.Columns.Count - 1;
        
        foreach (var column in columns)
        {
            var fillValue = string.Empty.PadRight(column.Width + 2, table.SideY);

            if (index == 0 && index == maxIndex)
                result += $"{table.VertexTopLeft}{fillValue}{table.VertexTopRight}\n";
            else if (index == 0)
                result += $"{table.VertexTopLeft}{fillValue}";
            else if (index == maxIndex)
                result += $"{table.VertexTop}{fillValue}{table.VertexTopRight}\n";
            else
                result += $"{table.VertexTop}{fillValue}";

            index++;
        }

        return result;
    }

    private static string GenerateNames(Table table)
    {
        var index = 0;
        var result = string.Empty;
        var columns = table.Columns;
        var maxIndex = table.Columns.Count - 1;
        
        foreach (var column in columns)
        {
            var headerValue = column.Name
                .Substring(0, Math.Min(column.Name.Length, column.Width))
                .PadRight(column.Width, ' ');
            
            if (index != maxIndex)
                result += $"{table.SideX} {headerValue} ";
            else
                result += $"{table.SideX} {headerValue} {table.SideX}\n";

            index++;
        }

        return result;
    }

    private static string GenerateBottomBorder(Table table)
    {
        var index = 0;
        var result = string.Empty;
        var columns = table.Columns;
        var maxIndex = table.Columns.Count - 1;
        
        foreach (var column in columns)
        {
            var fillValue = string.Empty.PadRight(column.Width + 2, table.SideY);
            
            if (index == 0 && index == maxIndex)
                result += $"{table.VertexLeft}{fillValue}{table.VertexRight}\n";
            else if (index == 0)
                result += $"{table.VertexLeft}{fillValue}";
            else if (index == maxIndex)
                result += $"{table.VertexMiddle}{fillValue}{table.VertexRight}\n";
            else
                result += $"{table.VertexMiddle}{fillValue}";

            index++;
        }

        return result;
    }

    public static void Display(Table table)
    {
        Console.Write(
            GenerateTopBorder(table) +
            GenerateNames(table) +
            GenerateBottomBorder(table)
        );
    }
}

public class Row
{
    private List<string> Values = new();
    
    public Row(List<string> values)
    {
        Values = values;
    }

    private static string GenerateValue(Table table, Row row)
    {
        var widths = table.Columns
            .Select((column) => column.Width)
            .ToList();
        var result = "";
        var index = 0;
        var values = row.Values;
        var maxIndex = table.Columns.Count - 1;

        foreach (var value in values)
        {
            var width = widths[index];
            var colValue = value.Substring(0, Math.Min(value.Length, width)).PadRight(width, ' ');

            if (index != maxIndex)
                result += $"{table.SideX} {colValue} ";
            else
                result += $"{table.SideX} {colValue} {table.SideX}\n";

            index++;
        }

        return result;
    }

    private static string GenerateBottomBorder(Table table)
    {
        var index = 0;
        var result = string.Empty;
        var columns = table.Columns;
        var maxIndex = table.Columns.Count - 1;
        
        foreach (var column in columns)
        {
            var fillValue = string.Empty.PadRight(column.Width + 2, table.SideY);
            
            if (index == 0 && index == maxIndex)
                result += $"{table.VertexBottomLeft}{fillValue}{table.VertexBottomRight}\n";
            else if (index == 0)
                result += $"{table.VertexBottomLeft}{fillValue}";
            else if (index == maxIndex)
                result += $"{table.VertexBottom}{fillValue}{table.VertexBottomRight}\n";
            else
                result += $"{table.VertexBottom}{fillValue}";

            index++;
        }

        return result;
    }

    public static void DisplayAll(Table table)
    {
        var rows = table.Rows;

        rows.ForEach(r => Console.Write(GenerateValue(table, r)));
        Console.Write(GenerateBottomBorder(table));
    }
}