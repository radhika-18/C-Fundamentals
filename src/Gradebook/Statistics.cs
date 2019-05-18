using System;

namespace Gradebook {
    public class Statistics {
        public double average;
        public double lowgrade;
        public double highgrade;
        private int gradeCount;
        private double sum;

        public Statistics () {
            this.average = 0.0;
            this.sum = 0.0;
            this.lowgrade = double.MaxValue;
            this.highgrade = double.MinValue;
            this.gradeCount = 0;
        }

        public void CalculateStatistics (double grade) {
            gradeCount++;
            sum += grade;
            average = sum / gradeCount;
            lowgrade = Math.Min (grade, lowgrade);
            highgrade = Math.Max (grade, highgrade);
        }
    }
}