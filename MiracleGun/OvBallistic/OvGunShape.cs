﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiracleGun.OvBallistic {
    public class OvGunShape: GunShape {
        GunShape sShape;
        public OvGunShape() : base() {
            sShape = new GunShape(d => Math.PI * d * d * 0.25);
        }
        public double Square(double x) {
            return sShape.GetV(x);
        }
        public override void Synch() {
            base.Synch();
            sShape.Clear();
            foreach (var p in xd_lst) {
                sShape.AddPoint(p.x, p.y);
            }
            sShape.Synch();
        }
        //public OvGunShape() : base() {

        //}
        //public double Square(double x) {
        //    var d = GetV(x);
        //    return Math.PI * d * d * 0.25;
        //}
        /// <summary>
        /// Получение производной поверхности в данной точке
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Get_dS(double x) {
            if (!isSynch)
                Synch();
            return sShape.Get_dV(x);
        }
    }
}
