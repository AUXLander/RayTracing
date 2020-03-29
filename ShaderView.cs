using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using System.Windows.Forms;
using System.Threading.Tasks;

enum ShaderStatus
{
    OK = 1,
    NotInitilized = 0,
    FileNotFound = -1,
    UnknownShaderFileType = -2,
}



class ShaderView
{
    private int Width;
    private int Height;
    private int VWidth;
    private int VHeight;

    private int BasicProgramID;
    private int BasicVertexShader;
    private int BasicFragmentShader;
    private ShaderStatus Status = ShaderStatus.NotInitilized;

    public ShaderView(int width, int height, int vwidth, int vheight)
    {
        Width = Math.Abs(width);
        Height = Math.Abs(height);

        VWidth = Math.Abs(vwidth);
        VHeight = Math.Abs(vheight);

        InitShader();

        InitView(vwidth, vheight);
    }

    private void InitShader()
    {
        BasicProgramID = GL.CreateProgram();

        LoadShader("C:\\Users\\auxla\\source\\repos\\RayTracing\\Shaders\\RayTracing.vert", BasicProgramID, out BasicVertexShader);
        LoadShader("C:\\Users\\auxla\\source\\repos\\RayTracing\\Shaders\\RayTracing.frag", BasicProgramID, out BasicFragmentShader);

        GL.LinkProgram(BasicProgramID);

        int status;
        GL.GetProgram(BasicProgramID, GetProgramParameterName.LinkStatus, out status);
        Console.WriteLine(GL.GetProgramInfoLog(BasicProgramID));
    }
    public void LoadShader(string filename, int program, out int address)
    {
        address = -1;
        if (File.Exists(filename))
        {
            ShaderType type;
            switch (Path.GetExtension(filename))
            {
                case ".vert":
                    {
                        type = ShaderType.VertexShader;
                    }; break;
                case ".frag":
                    {
                        type = ShaderType.FragmentShader;
                    }; break;

                default:
                    {
                        Status = ShaderStatus.UnknownShaderFileType;
                        return;
                    }; 
            }

            LoadShader(filename, type, program, out address);
        }
        else {
            Status = ShaderStatus.FileNotFound;
        }
    }

    public void LoadShader(string filename, ShaderType type, int program, out int address)
    {
        address = GL.CreateShader(type);
        if (File.Exists(filename))
        {
            
            StreamReader Reader = new StreamReader(filename);
            
            GL.ShaderSource(address, Reader.ReadToEnd());

            GL.CompileShader(address);
            GL.AttachShader(program, address);

            Console.WriteLine(GL.GetShaderInfoLog(address));

            Reader.Close();

            Status = ShaderStatus.OK;
        }
        else {
            Status = ShaderStatus.FileNotFound;
        }
    }

    public void InitView(int ViewWidth = 800, int ViewHeight = 600)
    {
        GL.ShadeModel(ShadingModel.Smooth);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        GL.Ortho(0, Width, 0, Height, -1, 1);
        GL.Viewport(0, 0, VWidth, VHeight);
    }

    public void DrawQuads()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        GL.UseProgram(BasicProgramID);

        GL.Begin(PrimitiveType.Quads);

        GL.Vertex2(-Width, -Height);
        GL.Vertex2(Width, -Height);
        GL.Vertex2(Width, Height);
        GL.Vertex2(-Width, Height);

        GL.End();
    }
}