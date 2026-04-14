# Unigram

**Unigram** is a lightweight C# desktop application built with SharpDevelop that recreates any simple mathematical formula as an interactive plot in a Cartesian coordinate system. Perfect for students, teachers, and math enthusiasts visualizing functions like `y = sin(x)`, `y = x²`, or custom equations.

## Features
- Parse and plot simple mathematical formulas (trigonometric, polynomial, exponential functions)
- Interactive Cartesian coordinate system with zoom, pan, and grid
- Real-time formula evaluation and graphing
- Adjustable axis ranges and scales
- Multiple functions on the same plot
- Export plots as images
- Clean, minimal UI focused on mathematics

## Screenshots
*(Add screenshots of the plotting interface here)*

## Requirements
- **.NET Framework 4.5** or higher
- **Windows 7/10/11**
- **SharpDevelop 4.4** (development environment)

## Installation
1. Clone or download this repository
2. Open `Unigram.sln` in SharpDevelop
3. Build the solution (`F6` or Build → Build Solution)
4. Run `Unigram.exe` from the `bin/Debug` or `bin/Release` folder

## Usage
1. Enter your formula in the input field (e.g., `sin(x)`, `x^2`, `2*x+3`, `cos(x)+sin(x)`)
2. Adjust X-axis range if needed (default: -10 to 10)
3. Click **Plot** to generate the graph
4. Use mouse wheel to zoom, drag to pan
5. Add multiple formulas using the **+** button
6. Export via **File → Save Plot As...**

### Supported Functions
```
Basic: x, const, +, -, *, /
Power: ^ (e.g., x^2)
Trigonometric: sin(x), cos(x), tan(x)
Logarithmic: log(x), ln(x)
Constants: pi, e
Parentheses: (x+1)*(x-2)
```

## Building from Source
```
1. Open SharpDevelop
2. File → Open → Unigram.sln
3. Build → Build Solution (F6)
4. Run → Debug (F5)
```

## Project Structure
```
Unigram/
├── Unigram.sln              # Solution file
├── Unigram.csproj          # Main project
├── src/
│   ├── Program.cs          # Entry point
│   ├── FormulaParser.cs    # Mathematical expression parser
│   ├── Plotter.cs          # Cartesian plotting engine
│   ├── MainForm.Designer.cs # UI forms
│   └── ...
├── bin/Debug/              # Compiled executable
└── README.md
```

## Development
- **IDE**: SharpDevelop 4.4
- **Language**: C# (.NET Framework)
- **Libraries**: Windows Forms for UI, custom math parser

Built with SharpDevelop's excellent form designer and debugging tools.

## Known Limitations
- Single-variable functions only (y = f(x))
- No 3D plotting
- Basic formula parsing (no advanced calculus)

## License
MIT License - see [LICENSE](LICENSE) file.

## Contributing
1. Fork the repository
2. Create feature branch (`git checkout -b feature/formula-support`)
3. Commit changes (`git commit -m "Add support for logarithmic functions"`)
4. Push and open Pull Request

***

**Created with ❤️ using SharpDevelop**  
*Visualize math, simply.*
