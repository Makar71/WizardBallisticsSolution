﻿using MiracleGun.Invariants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardBallistics.Core;
using static System.Math;

namespace MiracleGun.IdealGas {
    public class GasBound:WBOneDemNode {
        public GasCell LeftCell, RightCell;
        public GunShape Geom;
        public WBVec flux = WBVec.Zeros(3);
        public WBVec AUSMp() {
            double r1 = LeftCell.ro;
            double u1 = LeftCell.u;
            double e1 = LeftCell.e;

            double r2 = RightCell.ro;
            double u2 = RightCell.u;
            double e2 = RightCell.e;

            double p1 = LeftCell.p;
            double p2 = RightCell.p;

            double H1 = LeftCell.H;
            double H2 = RightCell.H;

            double c1 = LeftCell.CSound;
            double c2 = RightCell.CSound;

            double cs = 0.5 * (c1 + c2);
            double Mr1 = (u1 -V) / cs;
            double Mr2 = (u2 -V) / cs;
            double du = u2 - u1;

            double M4p = Abs(Mr1) >= 1d
                ? 0.5 * (Mr1 + Abs(Mr1))
                : 0.25 * ((Mr1 + 1.0) * (Mr1 + 1.0)) * (1.0 + 2.0 * 0.25 * (Mr1 - 1.0) * (Mr1 - 1.0));
            double P5p = Abs(Mr1) >= 1d
                ? 0.5 * (Mr1 + Abs(Mr1)) / Mr1
                : 0.25 * ((Mr1 + 1.0) * (Mr1 + 1.0)) * ((2.0 - Mr1) + 3.0 * Mr1 * 0.25 * (Mr1 - 1.0) * (Mr1 - 1.0));


            double M4m = Abs(Mr2) >= 1d
                ? 0.5 * (Mr2 - Abs(Mr2))
                : -0.25 * ((Mr2 - 1.0) * (Mr2 - 1.0)) * (1.0 + 2.0 * 0.25 * (Mr2 + 1.0) * (Mr2 + 1.0));

            double P5m = Abs(Mr2) >= 1d
                ? 0.5 * (Mr2 - Abs(Mr2)) / Mr2
                : 0.25 * ((Mr2 - 1.0) * (Mr2 - 1.0)) * ((2.0 + Mr2) - 3.0 * Mr2 * 0.25 * (Mr2 + 1.0) * (Mr2 + 1.0));

            double Mrf = M4p + M4m;
            double pf = P5p * p1 + P5m * p2;

            double flux1 = 0.5 * (cs * Mrf * (r1 + r2) - cs * Abs(Mrf) * (r2 - r1));
            double flux2 = 0.5 * (cs * Mrf * (r1 * u1 + r2 * u2) - cs * Abs(Mrf) * (r2 * u2 - r1 * u1)) + pf;
            double flux3 = 0.5 * (cs * Mrf * (r1 * H1 + r2 * H2) - cs * Abs(Mrf) * (r2 * H2 - r1 * H1)) + pf * V;
            return new WBVec(flux1, flux2, flux3);
        }
        public void SetFlux() {
            flux = AUSMp();
        }
        /// <summary>
        /// Площадь ствола в месте этой границы
        /// </summary>
        public double S => Geom.Square(X);
    }
}
