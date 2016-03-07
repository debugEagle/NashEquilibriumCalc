using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolNash
{
    public class Range
    {
        public float[] probability;

        public Range()
        {
            probability = new float[169];
        }

        public Range(float p)
        {
            probability = new float[169];
            if (p < 1.00001 && p >= 0.0)
            {
                for (int i = 0; i < 169; i++)
                {
                    probability[i] = p;
                }
            }
        }

        public override String ToString()
        {
            // counting in probabilities more than threshold:
            double threshold = 0.8;

            String res = String.Empty;
            // pocket pairs:
            int first = 0, last = 168;
            for (int k = 0; k < 13; k++)
            {
                if (probability[k * 13 + k] <= threshold)
                {
                    if (k == 0) { first = (k + 1) * 13 + (k + 1); continue; }
                    last = (k - 1) * 13 + (k - 1);
                    if (first == 0)
                    {
                        res += Hand.IntToString(last) + "+ ";
                    }
                    else if (first < last)
                    {
                        if (first != last)
                            res += Hand.IntToString(last) + "-" + Hand.IntToString(first) + " ";
                        else
                            res += Hand.IntToString(last) + " ";
                    }

                    first = (k + 1) * 13 + (k + 1);
                }
                else
                {
                    if (k == 12)
                    {
                        last = k * 13 + k;
                        if (first == 0)
                        {
                            res += Hand.IntToString(last) + "+ ";
                        }
                        else
                        {
                            if (first != last)
                                res += Hand.IntToString(first) + "-" + Hand.IntToString(last) + " ";
                            else
                                res += Hand.IntToString(last) + " ";
                        }
                    }
                }
            }

            

            // suited:
            for (int v = 0; v < 12; v++)
            {
                last = (v + 1) * 13 - 1;
                first = last - (11 - v);
                int f = first, l = last;
                for (int k = first; k <= last; k++)
                {
                    if (probability[k] <= threshold)
                    {
                        if (k == first) { f = k + 1; continue; }
                        l = k - 1;
                        if (f == first) res += Hand.IntToString(l) + "+ ";
                        else if (f < l)
                        {
                            if (f != l)
                                res += Hand.IntToString(f) + "-" + Hand.IntToString(l) + " ";
                            else
                                res += Hand.IntToString(l) + " ";
                        }

                        f = k + 1;
                    }
                    else
                    {
                        if (k == last)
                        {
                            l = k;
                            if (f == first)
                            {
                                res += Hand.IntToString(l) + "+ ";
                            }
                            else
                            {
                                if (f != l)
                                    res += Hand.IntToString(f) + "-" + Hand.IntToString(l) + " ";
                                else
                                    res += Hand.IntToString(l) + " ";
                            }
                        }
                    }
                }
            }

            // offsuit:
            for (int v = 0; v < 12; v++)
            {
                last = (v + 1) * 13 - 1;
                first = last - (11 - v);
                int f = first, l = last;
                for (int k = first; k <= last; k++)
                {
                    if (probability[(first + 12) + 13 * (k - first)] <= threshold)
                    {
                        if (k == first) { f = k + 1; continue; }
                        l = k - 1;
                        if (f == first) res += Hand.IntToString((first + 12) + 13 * (l - first)) + "+ ";
                        else if (f < l)
                        {
                            if (f != l)
                                res += Hand.IntToString((first + 12) + 13 * (f - first)) + "-" +
                                    Hand.IntToString((first + 12) + 13 * (l - first)) + " ";
                            else
                                res += Hand.IntToString((first + 12) + 13 * (l - first)) + " ";
                        }
                        f = k + 1;
                    }
                    else
                    {
                        if (k == last)
                        {
                            l = k;
                            if (f == first)
                            {
                                res += Hand.IntToString((first + 12) + 13 * (l - first)) + "+ ";
                            }
                            else
                            {
                                if (f != l)
                                    res += Hand.IntToString((first + 12) + 13 * (f - first)) + "-" + Hand.IntToString((first + 12) + 13 * (l - first)) + " ";
                                else
                                    res += Hand.IntToString(l) + " ";
                            }
                        }
                    }
                }
            }


            return res;
        }

        public void UpdateRange(Range r2, double p)
        {
            for (int i = 0; i < 169; i++)
            {
                this.probability[i] = this.probability[i] * (float)p + r2.probability[i] * (float)(1.0 - p);
            }
        }

        public double TotalProbability()
        {
            double total = 0.0;
            for (int i = 0; i < 169; i++)
            {
                if (i % 13 > i / 13)
                    total += probability[i] * 4.0;
                else if (i % 13 < i / 13)
                    total += probability[i] * 12.0;
                else total += probability[i] * 6.0;
            }
            return total / 1326.0;
        }
    }
}
