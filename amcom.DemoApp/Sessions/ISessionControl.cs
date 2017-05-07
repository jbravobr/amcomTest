namespace amcom.DemoApp
{
	public interface ISessionControl
	{
		void SaveSession();
		void DeleteSession();
		Session GetSavedSession();
		bool IsValid();
	}
}