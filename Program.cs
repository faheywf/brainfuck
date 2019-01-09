using System;

namespace brainfuck
{
    class Program
    {
        const int MEM_SIZE = 30000;
        
        static void Main(string[] args)
        {
            char[] memory = new char[MEM_SIZE];
            int ptr = 0;
            int pc = 0;
            Console.WriteLine("Give me some BF to execute");
            string input = Console.ReadLine();

            while(pc < input.Length){
                //Console.WriteLine($"PC: {pc} Input: {input[pc]} Ptr: {ptr} Value: {(int)memory[ptr]}");
                switch (input[pc]){
                    case '>':
                        ptr++;
                        if(ptr > MEM_SIZE){
                            ptr = 0;
                        }
                        pc++;
                        break;
                    case '<':
                        ptr--;
                        if(ptr < 0){
                            ptr = MEM_SIZE - 1;
                        }
                        pc++;
                        break;
                    case '+':
                        memory[ptr]++;
                        pc++;
                        break;
                    case '-':
                        memory[ptr]--;
                        pc++;
                        break;
                    case '.':
                        Console.Write(memory[ptr]);
                        pc++;
                        break;
                    case ',':
                        memory[ptr] = (char)Console.Read();
                        pc++;
                        break;
                    case '[':
                        if(memory[ptr] == 0){
                            int closings = 1;
                            pc++;
                            while(closings != 0){
                                if(input[pc] == '['){
                                    closings++;
                                }
                                if(input[pc] == ']'){
                                    closings--;
                                }
                                pc++;
                            }
                        }
                        pc++;
                        break;
                    case ']':
                        if(memory[ptr] != 0){
                            int openings = 1;
                            pc--;
                            while(openings != 0){
                                if(input[pc] == ']'){
                                    openings++;
                                }
                                if(input[pc] == '['){
                                    openings--;
                                }
                                pc--;
                            }
                        }
                        pc++;
                        break;
                    default:
                        pc++;
                        break;
                }
            }
        }
    }
}
