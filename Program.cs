using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerChips

//    Хосе установил круглый стол для игры в покер для своих друзей таким образом, чтобы на каждом из сидящих за столом было одинаковое количество фишек.
//Но когда Хосе отвернулся, кто-то переставил все фишки так, что они перестали быть равномерно распределенными!
//Теперь Хосе нужно перераспределить фишки так, чтобы на каждом месте было одинаковое количество фишек до прихода его друзей.
//Но Хосе очень скрупулезен: чтобы не потерять ни одной фишки в процессе, он передвигает фишки только между соседними местами.
//Более того, он передвигает фишки только по одной за раз. Каково минимальное количество ходов фишек
//Что нужно будет сделать Хосе, чтобы вернуть фишки в равновесие?

{
    internal class Program
    {     
        static void Main(string[] args)
        {
            int countChips = 0;

            Console.WriteLine("Write a list containing of the count of chips at each place at the table, separated by a space\nFor example: 1 2 3 7 2 4");
            var arrayChips = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);

            for (int i = 0; i < arrayChips.Length; i++)
            {             
                countChips += arrayChips[i];
            }

            Console.WriteLine("Count chips: {0}", countChips.ToString());
          
            var avgChips =  arrayChips.Average();

            Console.WriteLine("Average count chips: {0}", avgChips.ToString());

            int countSteps = 0;

            var countCorrectChips = 0;

            for (int i = 1; countCorrectChips != arrayChips.Length; i++)
            {
                int indexMax = 0;

                // Узнаем индекс нахождения максимального числа в массиве
                for(int j = 0; j < arrayChips.Length; j++)
                {
                    if (arrayChips[j] == arrayChips.Max())
                    {
                        indexMax = j;
                        break;
                    }
                }

                // Создаем переменные для чисел находящихся слева и справа от максимального
                int leftChipsIndex;
                if (indexMax - 1 == -1)
                {
                    leftChipsIndex = arrayChips.Length - 1;
                }
                else
                {
                    leftChipsIndex = indexMax - 1;
                }
                

                int rightChipsIndex = 0;
                if (indexMax + 1 == arrayChips.Length)
                {
                    rightChipsIndex = 0;
                }
                else
                {
                    rightChipsIndex = indexMax + 1;
                }

                // Проверяем какое число от максимального меньше, то что слева или справа
                if (arrayChips[rightChipsIndex] < arrayChips.Max() && arrayChips[leftChipsIndex] > arrayChips[rightChipsIndex])
                {
                    arrayChips[indexMax]--;
                    arrayChips[rightChipsIndex]++;
                }
                else if (arrayChips[leftChipsIndex] < arrayChips.Max() && arrayChips[rightChipsIndex] > arrayChips[leftChipsIndex])
                {
                    arrayChips[indexMax]--;
                    arrayChips[leftChipsIndex]++;
                }
                // Если они одинаковые то ищем числа правее и левее
                else if (arrayChips[rightChipsIndex] == arrayChips[leftChipsIndex])
                {
                    int flag = 0;
                    
                    for (int j = 2;  j < arrayChips.Length/2 || flag!= 1; j++)
                    {
                        // Создаем переменные для чисел находящихся левее и правее от максимального           
                        if (indexMax - j == -1)
                        {
                            leftChipsIndex = arrayChips.Length - 1;
                        }
                        else
                        {
                            leftChipsIndex = indexMax - j;
                        }

                        if (indexMax + j == arrayChips.Length)
                        {
                            rightChipsIndex = 0;
                        }
                        else
                        {
                            rightChipsIndex = indexMax + j;
                        }

                        // Проверяем какое число от максимального меньше, то что левее или правее
                        if (arrayChips[rightChipsIndex] < arrayChips.Max() && arrayChips[leftChipsIndex] > arrayChips[rightChipsIndex])
                        {
                            arrayChips[indexMax]--;
                            if (indexMax + j == arrayChips.Length)
                            {
                                arrayChips[0]++;
                            }
                            else
                            {
                                arrayChips[indexMax + 1]++;
                            }
                            
                            flag = 1;
                        }
                        else if (arrayChips[leftChipsIndex] < arrayChips.Max() && arrayChips[rightChipsIndex] > arrayChips[leftChipsIndex])
                        {
                            arrayChips[indexMax]--;
                            if (indexMax - j == -1)
                            {
                                arrayChips[arrayChips.Length-1]++;
                            }
                            else
                            {
                                arrayChips[indexMax - 1]++;
                            }

                            flag = 1;
                        }                       
                    }
                }

                countSteps++;

                for (int j = 0; j < arrayChips.Length; j++)
                {
                    if (arrayChips[j] == avgChips) countCorrectChips++;
                    else countCorrectChips = 0;
                }

                var str = string.Join(" ", arrayChips);
                Console.WriteLine(str);            
            }

            Console.WriteLine("Count steps: {0}", countSteps.ToString());
        }
    }
}
