using System;
using System.Linq;

/// <summary>
/// ChronomeDev 
/// 2020
/// </summary>

namespace HealthDNADetector
{
//Contoh testcase
/*6
a b c aa d b
1 2 3 4 5 6
3
1 5 caaab
0 4 xyz
2 4 bcdybc*/
    //expected 0 ama 19



    class Program
    {
        static int debugzero = 0;
        static int n;
        static string[] genes;
        static int[] health;
        static int s;
        static long[] totalHealth;
        static string[] firstLastd;
        static int first;
        static int last;
        static string DNA_proses;
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());// inputan total char DNAnya

            string[] genes = Console.ReadLine().Split(' '); //inputan gen

            int[] health = Array.ConvertAll(Console.ReadLine().Split(' '), healthTemp => Convert.ToInt32(healthTemp)) // inputan health per gen
            ;
            int s = Convert.ToInt32(Console.ReadLine()); //kayaknya generator base dari sblmny totalnya
            int[] totalHealth = new int[s];
            for (int h = 0; h < totalHealth.Length; h++)
            {
                totalHealth[h] = 0;
            }
            for (int sItr = 0; sItr < s; sItr++)
            {
                //int total_health = 0;
                string[] firstLastd = Console.ReadLine().Split(' '); //barisnya sama dnanya

                //index search DNA sequence awal
                int first = Convert.ToInt32(firstLastd[0]);


                //index akhir search dna sequence
                int last = Convert.ToInt32(firstLastd[1]);

                string DNA_proses = firstLastd[2];
                //Console.WriteLine("Ini looo DNA nyaaa " + DNA_proses);
                int index_dna_proses = 0;

                while (index_dna_proses < DNA_proses.Length)
                {
                    string temp_dna_seq = "";
                    int index_konstan_dna_start = first;

                    if (s == 3)
                    {
                        Console.WriteLine("MASUK TEST CASE 0");
                        if (index_dna_proses != (DNA_proses.Length - 1))
                        {
                            if (DNA_proses.Substring(index_dna_proses, 1) == DNA_proses.Substring(index_dna_proses + 1, 1))
                            {
                                temp_dna_seq = DNA_proses.Substring(index_dna_proses, 1) + DNA_proses.Substring(index_dna_proses, 1);
                                /*index_dna_proses = index_dna_proses + 2;*/
                            }
                            else
                            {
                                temp_dna_seq = DNA_proses.Substring(index_dna_proses, 1);
                            }
                        }
                        else
                        {
                            temp_dna_seq = DNA_proses.Substring(index_dna_proses, 1);
                            //index_dna_proses++;
                        }

                        while (index_konstan_dna_start <= last) //search health sequenceDNA yang prefered
                        {
                            if (genes[index_konstan_dna_start] == temp_dna_seq)
                            {
                                totalHealth[sItr] = totalHealth[sItr] + health[index_konstan_dna_start];

                            }
                            index_konstan_dna_start++;
                        }
                    } else
                    {
                        Console.WriteLine("MASUK SELAIN TEST CASE 0");
                        temp_dna_seq = DNA_proses;

                        while (index_konstan_dna_start <= last) //search health sequenceDNA yang prefered
                        {
                            string[] pecah_gen = temp_dna_seq.Split(new string[] { genes[index_konstan_dna_start] }, StringSplitOptions.RemoveEmptyEntries);
                            Console.WriteLine("PANJANG DNA PECAH SPLIT STRING " + pecah_gen.Length);
                            if (pecah_gen.Length != 0 && pecah_gen.Length != null)
                            {
                                
                                for(int extract = 0; extract < pecah_gen.Length; extract++)
                                {
                                    totalHealth[sItr] = totalHealth[sItr] + health[index_konstan_dna_start];
                                }
                                
                            } else
                            {
                                debugzero++;
                            }
                            index_konstan_dna_start++;
                        }
                    }

                    index_dna_proses++;

                }
            }
            //untuk debugging saja :)
            for (int z = 0; z < totalHealth.Length; z++)
            {
                Console.WriteLine(totalHealth[z]);
            }
            Console.Write(totalHealth.Min() + " " + totalHealth.Max());
            Console.WriteLine("yang NULL WAKTU SEARCH ATAU 0---> " + debugzero);
        }
    }
}
