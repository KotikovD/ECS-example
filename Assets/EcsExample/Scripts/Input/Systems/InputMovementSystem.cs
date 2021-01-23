using Entitas;
using UnityEngine;


public class InputMovementSystem : IExecuteSystem, IInitializeSystem
{
	private readonly InputContext _contextsInput;
	private InputEntity _inputEntity;

	public InputMovementSystem(Contexts contexts)
	{
		_contextsInput = contexts.input;
	}

	public void Initialize()
	{
		 _inputEntity = _contextsInput.CreateEntity();
	}
	
	public void Execute()
	{
		var verticalAxisValue = Input.GetAxis("Vertical");
		var horizontalAxisValue = Input.GetAxis("Horizontal");

		_inputEntity.ReplacePlayerUnitMove(horizontalAxisValue, verticalAxisValue);
	}
	
}