using System;

namespace Lab4CSharp
{
    /// <summary>
    ///  Top-level statements 
    ///  Код програми (оператори)  вищого рівня
    /// </summary>
    ///
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 2 ");
            VectorInt vec1 = new VectorInt(3, 5); // Vector of size 3 initialized with value 5
            VectorInt vec2 = new VectorInt(3); // Vector of size 3 initialized with zeros
            vec2.Input(); // Input values for vec2 from user

            Console.WriteLine("Vector 1: ");
            vec1.Output();
            Console.WriteLine("Vector 2: ");
            vec2.Output();

            VectorInt vec3 = vec1 + vec2; // Adding two vectors
            Console.WriteLine("Vector 3 (Sum): ");
            vec3.Output();

            ++vec1; // Increment all elements of vec1
            Console.WriteLine("Vector 1 after increment: ");
            vec1.Output();

            Console.WriteLine("Number of vectors created: " + VectorInt.GetNumVec());

            // Example of classes Person, Student, Teacher, DepartmentHead
            Person[] people = new Person[]
            {
                new Student { Name = "John", Age = 20, StudentID = "S12345", Major = "Computer Science" },
                new Student { Name = "Alice", Age = 21, StudentID = "S23456", Major = "Mathematics" },
                new Teacher { Name = "Mr. Smith", Age = 35, Department = "Computer Science", Subject = "Programming" },
                new Teacher { Name = "Ms. Johnson", Age = 40, Department = "Mathematics", Subject = "Calculus" },
                new DepartmentHead { Name = "Dr. Brown", Age = 50, Department = "Computer Science", Subject = "Computer Science", YearsOfExperience = 20 },
                new DepartmentHead { Name = "Dr. White", Age = 55, Department = "Mathematics", Subject = "Mathematics", YearsOfExperience = 25 }
            };

            Console.WriteLine("Exercise 1:");
            Console.WriteLine("People sorted by age:");
            Array.Sort(people, (x, y) => x.Age.CompareTo(y.Age));
            foreach (var person in people)
            {
                person.Show();
            }

            // Exercise 3: MatrixInt object
            Console.Write("Enter number of rows: ");
            int rows = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number of columns: ");
            int cols = Convert.ToInt32(Console.ReadLine());

            MatrixInt mat1 = new MatrixInt(rows, cols);
            Console.WriteLine($"MatrixInt object created with {rows}x{cols} dimensions.");
            mat1.InputValues();

            Console.WriteLine($"Number of matrices created: {MatrixInt.CountMatrices()}");

            Console.WriteLine("Printing matrix elements:");
            mat1.PrintValues();
        }
    }

    /// <summary>
    /// VectorInt class with vector operations
    /// Клас VectorInt з операціями векторних обчислень
    /// </summary>
    class VectorInt
    {
        private int[] IntArray; // array
        private uint size; // vector size
        private int codeError; // error code
        private static uint num_vec; // number of vectors

        // Constructors
        public VectorInt()
        {
            size = 1;
            IntArray = new int[size];
            IntArray[0] = 0;
            codeError = 0;
            num_vec++;
        }

        public VectorInt(uint s)
        {
            size = s;
            IntArray = new int[size];
            for (uint i = 0; i < size; ++i)
            {
                IntArray[i] = 0;
            }
            codeError = 0;
            num_vec++;
        }

        public VectorInt(uint s, int init_value)
        {
            size = s;
            IntArray = new int[size];
            for (uint i = 0; i < size; ++i)
            {
                IntArray[i] = init_value;
            }
            codeError = 0;
            num_vec++;
        }

        // Methods
        public void Input()
        {
            for (uint i = 0; i < size; ++i)
            {
                Console.WriteLine("Enter element " + i + ": ");
                IntArray[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void Output()
        {
            for (uint i = 0; i < size; ++i)
            {
                Console.Write(IntArray[i] + " ");
            }
            Console.WriteLine();
        }

        public void Assign(int value)
        {
            for (uint i = 0; i < size; ++i)
            {
                IntArray[i] = value;
            }
        }

        public static uint GetNumVec()
        {
            return num_vec;
        }

        // Properties
        public uint Size
        {
            get { return size; }
        }

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        // Indexer
        public int this[uint index]
        {
            get
            {
                if (index >= size)
                {
                    codeError = -1;
                    return IntArray[0];
                }
                return IntArray[index];
            }
            set
            {
                if (index < size)
                {
                    IntArray[index] = value;
                }
            }
        }

        // Unary operator overloading
        public static VectorInt operator ++(VectorInt vec)
        {
            for (uint i = 0; i < vec.size; ++i)
            {
                ++vec.IntArray[i];
            }
            return vec;
        }

        // Binary operator overloading
        public static VectorInt operator +(VectorInt vec1, VectorInt vec2)
        {
            uint newSize = (vec1.size > vec2.size) ? vec1.size : vec2.size;
            VectorInt result = new VectorInt(newSize);
            for (uint i = 0; i < newSize; ++i)
            {
                result.IntArray[i] = vec1[i] + vec2[i];
            }
            return result;
        }
    }

    /// <summary>
    /// MatrixInt class representing a matrix
    /// Клас MatrixInt, який представляє матрицю
    /// </summary>
    class MatrixInt
    {
        private int[,] IntArray; // array
        private int n, m; // matrix dimensions
        private int codeError; // error code
        private static int num_vec; // number of matrices

        // Constructors
        public MatrixInt()
        {
            n = 1;
            m = 1;
            IntArray = new int[n, m];
            num_vec++;
        }

        public MatrixInt(int rows, int cols)
        {
            n = rows;
            m = cols;
            IntArray = new int[n, m];
            num_vec++;
        }

        public MatrixInt(int rows, int cols, int initValue)
        {
            n = rows;
            m = cols;
            IntArray = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    IntArray[i, j] = initValue;
                }
            }
            num_vec++;
        }

        // Methods
        public void InputValues()
        {
            Console.WriteLine($"Enter {n}x{m} matrix elements:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Array[{i},{j}]: ");
                    IntArray[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        public void PrintValues()
        {
            Console.WriteLine("Printing matrix elements:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{IntArray[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        public static int CountMatrices()
        {
            return num_vec;
        }

        // Properties
        public int Rows => n;
        public int Columns => m;

        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }

        // Indexers
        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < n && j >= 0 && j < m)
                    return IntArray[i, j];
                else
                {
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                if (i >= 0 && i < n && j >= 0 && j < m)
                    IntArray[i, j] = value;
                else
                    codeError = -1;
            }
        }

        public int this[int k]
        {
            get
            {
                if (k >= 0 && k < n * m)
                {
                    int i = k / m;
                    int j = k % m;
                    return IntArray[i, j];
                }
                else
                {
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                if (k >= 0 && k < n * m)
                {
                    int i = k / m;
                    int j = k % m;
                    IntArray[i, j] = value;
                }
                else
                    codeError = -1;
            }
        }

        // Operator overloading
        public static MatrixInt operator ++(MatrixInt matrix)
        {
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    matrix.IntArray[i, j]++;
                }
            }
            return matrix;
        }

        public static bool operator true(MatrixInt matrix)
        {
            if (matrix.n != 0 && matrix.m != 0)
            {
                for (int i = 0; i < matrix.n; i++)
                {
                    for (int j = 0; j < matrix.m; j++)
                    {
                        if (matrix.IntArray[i, j] == 0)
                            return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static bool operator false(MatrixInt matrix)
        {
            return matrix.n != 0 && matrix.m != 0;
        }

        public static MatrixInt operator !(MatrixInt matrix)
        {
            return new MatrixInt(matrix.n, matrix.m, 1);
        }

        // Other overloads and operations as needed
    }

    // Define Person, Student, Teacher, and DepartmentHead classes
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual void Show()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    class Student : Person
    {
        public string StudentID { get; set; }
        public string Major { get; set; }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"StudentID: {StudentID}, Major: {Major}");
        }
    }

    class Teacher : Person
    {
        public string Department { get; set; }
        public string Subject { get; set; }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Department: {Department}, Subject: {Subject}");
        }
    }

    class DepartmentHead : Teacher
    {
        public int YearsOfExperience { get; set; }

        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Years of Experience: {YearsOfExperience}");
        }
    }
}
