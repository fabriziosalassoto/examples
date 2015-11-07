﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace Artem.Web.UI.Controls {

    public struct GoogleDistance : IStateManager {

        #region Static Fields ///////////////////////////////////////////////////////////

        public static readonly GoogleDistance Empty;

        #endregion

        #region Static Methods //////////////////////////////////////////////////////////

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(GoogleDistance a, GoogleDistance b) {
            return ((a.Meters == b.Meters) && (a.Html == b.Html));
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(GoogleDistance a, GoogleDistance b) {
            return !(a == b);
        }
        #endregion

        #region Fields  /////////////////////////////////////////////////////////////////

        public double Meters;
        public string Html;

        #endregion

        #region Methods /////////////////////////////////////////////////////////////////

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns>
        /// true if <paramref name="obj"/> and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object obj) {

            if (!(obj is GoogleDistance)) return false;
            GoogleDistance dist = (GoogleDistance)obj;
            return ((dist.Meters == this.Meters) && (dist.Html == this.Html));
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode() {
            return base.GetHashCode();
        }
        #endregion

        #region IStateManager Members ///////////////////////////////////////////////////

        bool _tracking;

        bool IStateManager.IsTrackingViewState {
            get { return _tracking; }
        }

        void IStateManager.LoadViewState(object savedState) {

            Pair state = savedState as Pair;
            if (state != null) {
                this.Meters = (double)state.First;
                this.Html = (string)state.Second;
            }
        }

        object IStateManager.SaveViewState() {
            return new Pair(this.Meters, this.Html);
        }

        void IStateManager.TrackViewState() {
            _tracking = true;
        }
        #endregion
    }
}
