using UnityEngine;

namespace Krivodeling.WeaponSystem
{
    public static class AnimationCurvePresets
    {
        public static AnimationCurve Linear(float timeStart, float valueStart, float timeEnd, float valueEnd, WrapMode preWrapMode = WrapMode.Clamp, WrapMode postWrapMode = WrapMode.Clamp)
        {
            var curve = AnimationCurve.Linear(timeStart, valueStart, timeEnd, valueEnd);

            curve.preWrapMode = preWrapMode;
            curve.postWrapMode = postWrapMode;

            return curve;
        }

        public static AnimationCurve Linear(WrapMode preWrapMode = WrapMode.Clamp, WrapMode postWrapMode = WrapMode.Clamp) => Linear(0f, 0f, 1f, 1f, preWrapMode, postWrapMode);
        public static AnimationCurve LinearInverted(WrapMode preWrapMode = WrapMode.Clamp, WrapMode postWrapMode = WrapMode.Clamp) => Linear(0f, 1f, 1f, 0f, preWrapMode, postWrapMode);

        public static AnimationCurve EaseInOut(float timeStart, float valueStart, float timeEnd, float valueEnd, WrapMode preWrapMode = WrapMode.Clamp, WrapMode postWrapMode = WrapMode.Clamp)
        {
            var curve = AnimationCurve.EaseInOut(timeStart, valueStart, timeEnd, valueEnd);

            curve.preWrapMode = preWrapMode;
            curve.postWrapMode = postWrapMode;

            return curve;
        }

        public static AnimationCurve EaseInOut(WrapMode preWrapMode = WrapMode.Clamp, WrapMode postWrapMode = WrapMode.Clamp) => EaseInOut(0f, 0f, 1f, 1f, preWrapMode, postWrapMode);
        public static AnimationCurve EaseInOutInverted(WrapMode preWrapMode = WrapMode.Clamp, WrapMode postWrapMode = WrapMode.Clamp) => EaseInOut(0f, 1f, 1f, 0f, preWrapMode, postWrapMode);
    }
}
