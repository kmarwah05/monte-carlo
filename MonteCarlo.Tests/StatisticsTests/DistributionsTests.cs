﻿using Xunit;
using MonteCarlo.Models.Statistics;
using Newtonsoft.Json;
using MonteCarlo.Models;

namespace MonteCarlo.Tests.StatisticsTests
{
    public class DistributionsTests
    {
        [Fact]
        public void TestNormal()
        {
            ProbabilityDistribution normal = new NormalDistribution(mean: 0, standardDeviation: 1);
            double[] tester = new double[100];
            for (var i = 0; i < 100; i++)
            {
                tester[i] = normal.NextDouble();
            }

             string jsonResult = JsonConvert.SerializeObject(tester);
        }

        [Fact]
        public void TestLogNormal()
        {
            ProbabilityDistribution logNormal = new LogNormalDistribution(mean: 10.82, standardDeviation: 17.16);
            var mc = new BondsSimulation();

            var result = mc.Run(withProfile: new RunProfile()
            {
                SeedDistribution = DistributionPool.Instance.GetDistribution(Distribution.Normal, withPeakAt: 0.093, withScale: 27.814),
                StepDistribution = DistributionPool.Instance.GetDistribution(Distribution.Normal, withPeakAt: 10.82, withScale: 17.16),
                TrialLength = 30,
                ContributionLength = 15,
                InitialAmount = 10000,
                ContributionAmount = 500,
                WithdrawalAmount = 5000
            });
            string jsonResult = JsonConvert.SerializeObject(result);
        }

        [Fact]
        public void TestCauchy()
        {
            ProbabilityDistribution cauchy = new CauchyDistribution(location: 0.093, scale: 27.814);
            var mc = new BondsSimulation();

            var result = mc.Run(withProfile: new RunProfile()
            {
                SeedDistribution = DistributionPool.Instance.GetDistribution(Distribution.Normal, withPeakAt: 0.093, withScale: 27.814),
                StepDistribution = DistributionPool.Instance.GetDistribution(Distribution.Normal, withPeakAt: 10.82, withScale: 17.16),
                TrialLength = 30,
                ContributionLength = 15,
                InitialAmount = 10000,
                ContributionAmount = 500,
                WithdrawalAmount = 5000
            });
            string jsonResult = JsonConvert.SerializeObject(result);
        }

        [Fact]
        public void TestLaplace()
        {
            ProbabilityDistribution normal = new LaplaceDistribution(location:0, diversity:1);
            double[] tester = new double[100];
            for (var i = 0; i < 100; i++)
            {
                tester[i] = normal.NextDouble();
            }

            string jsonResult = JsonConvert.SerializeObject(tester);
        }

        [Fact]
        public void TestLogistic()
        {
            ProbabilityDistribution normal = new LogisticDistribution(location:0, scale:1);
            double[] tester = new double[100];
            for (var i = 0; i < 100; i++)
            {
                tester[i] = normal.NextDouble();
            }

            string jsonResult = JsonConvert.SerializeObject(tester);
        }
    }
}
