using OculusSampleFramework;
using UnityEngine;
using UnityEngine.Assertions;

public class ControllerBoxController : MonoBehaviour
{
	//[SerializeField] private TrainLocomotive _locomotive = null;
	//[SerializeField] private CowController _cowController = null;
	[SerializeField] private GameObject hole;
	
	public void StartStopStateChanged(InteractableStateArgs obj)
	{
		if (obj.NewInteractableState == InteractableState.ActionState)
		{
			Debug.Log("[ControllerBoxController] StartStopStateChanged");
			//_locomotive.StartStopStateChanged();
			hole.gameObject.SetActive(!hole.gameObject.activeSelf);
		}
	}
	
	public void SwitchVisualization(InteractableStateArgs obj)
	{
		if (obj.NewInteractableState == InteractableState.ActionState)
		{
			HandsManager.Instance.SwitchVisualization();
		}
	}

	public void GoMoo(InteractableStateArgs obj)
	{
		if (obj.NewInteractableState == InteractableState.ActionState)
		{
			Debug.Log("[ControllerBoxController] StartStopStateChanged");
			//_cowController.GoMooCowGo();
		}
	}
}
