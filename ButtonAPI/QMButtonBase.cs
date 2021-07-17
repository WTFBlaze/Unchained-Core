using UnityEngine;
using UnityEngine.UI;

namespace VRCMGU.API
{
    public class QMButtonBase
    {
        protected GameObject button;
        protected string btnQMLoc;
        protected string btnType;
        protected string btnTag;
        protected int[] initShift = { 0, 0 };
        protected Color OrigBackground;
        protected Color OrigText;

        public GameObject getGameObject()
        {
            return button;
        }

        public void setActive(bool isActive)
        {
            button.gameObject.SetActive(isActive);
        }

        public void setIntractable(bool isIntractable)
        {
            if (isIntractable)
            {
                setBackgroundColor(OrigBackground, false);
                setTextColor(OrigText, false);
            }
            else
            {
                setBackgroundColor(new Color(0.5f, 0.5f, 0.5f, 1), false);
                setTextColor(new Color(0.7f, 0.7f, 0.7f, 1), false); ;
            }
            button.gameObject.GetComponent<Button>().interactable = isIntractable;
        }

        public void setLocation(float buttonXLoc, float buttonYLoc)
        {
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 * (buttonXLoc + initShift[0]));
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 * (buttonYLoc + initShift[1]));

            btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
            button.name = btnQMLoc + "/" + btnType + btnTag;
            button.GetComponent<Button>().name = btnType + btnTag;
        }

        public void setToolTip(string buttonToolTip)
        {
            button.GetComponent<UiTooltip>().field_Public_String_0 = buttonToolTip;
        }

        public void setShader(string shaderName)
        {
            var Material = new Material(button.GetComponent<Image>().material);
            Material.shader = Shader.Find(shaderName);
            button.gameObject.GetComponent<Image>().material = Material;
        }

        public void setImage(Sprite img)
        {
            button.GetComponent<Image>().sprite = img;
            var orig = button.GetComponent<Button>().colors;
            var colors = new ColorBlock()
            {
                colorMultiplier = orig.colorMultiplier,
                disabledColor = orig.disabledColor,
                fadeDuration = orig.fadeDuration,
                highlightedColor = Color.white,
                normalColor = Color.white,
                pressedColor = orig.pressedColor
            };
            button.GetComponent<Button>().colors = colors;
        }

        public void DestroyMe()
        {
            try
            {
                UnityEngine.Object.Destroy(button);
            }
            catch { }
        }

        public void ClickMe()
        {
            button.GetComponent<Button>().onClick.Invoke();
        }

        public virtual void setBackgroundColor(Color buttonBackgroundColor, bool save = true) { }
        public virtual void setTextColor(Color buttonTextColor, bool save = true) { }
    }
}