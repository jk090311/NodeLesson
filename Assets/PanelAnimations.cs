using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class PanelAnimations : MonoBehaviour
{
    public void OpenSettingsPanel(Animator animator) => animator.SetBool("IsSettingOpen", true);
    public void CloseSettingsPanel(Animator animator) => animator.SetBool("IsSettingOpen", false);
    public void OpenAccPanel(Animator animator) => animator.SetBool("IsAccOpen", true);
    public void CloseAccPanel(Animator animator) => animator.SetBool("IsAccOpen", false);
    public void OpenTermsPanel(Animator animator) => animator.SetBool("IsTermsOpen", true);
    public void CloseTermsPanel(Animator animator) => animator.SetBool("IsTermsOpen", false);
    public void OpenAboutPanel(Animator animator) => animator.SetBool("IsAboutOpen", true);
    public void CloseAboutPanel(Animator animator) => animator.SetBool("IsAboutOpen", false);
    public void OpenCharChoosePanel(Animator animator) => animator.SetBool("IsCharOpen", true);
    public void CloseCharChoosePanel(Animator animator) => animator.SetBool("IsCharOpen", false);
    public void OpenExitPanel(Animator animator) => animator.SetBool("IsExitOpen", true);
    public void CloseExitPanel(Animator animator) => animator.SetBool("IsExitOpen", false);
    public void OpenMainMenuPanel(Animator animator) => animator.SetBool("IsSignInOpen", true);
    public void CloseMainMenuPanel(Animator animator) => animator.SetBool("IsSignInOpen", false);
    public void OpenGuestPanel(Animator animator) => animator.SetBool("IsGuestOpen", true);
    public void CloseGuestPanel(Animator animator) => animator.SetBool("IsGuestOpen", false);
}