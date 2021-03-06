﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WizardBallistics.Core;

namespace WizardBallistics.Core {
    /// <summary>
    /// Структура одномерной подвижной эйлеровой сетки
    /// </summary>
    /// <typeparam name="T">структура данных для конкретной задачи</typeparam>
    public class WBOneDemNode:WBNodeBase {
      
        /// <summary>
        /// индекс узла
        /// </summary>
        public int Index;

        /// <summary>
        /// индекс узла в списке Nodes
        /// </summary>
        public int IndexInList;

        /// <summary>
        /// координата узла в одномерном пространстве
        /// </summary>
        public double X;

        /// <summary>
        /// скорость узла в одномерном пространстве
        /// </summary>
        public double V;        
    }

}
