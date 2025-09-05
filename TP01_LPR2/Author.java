
public class Author {
	private String _name;
	private String _email;
	private char _gender;
	
	public Author(String name, String email, char gender){
		this._name = name;
		this._email = email;
		this._gender = gender;
	}
	
	public String getName() {
		return _name;
	}
	
	public String getEmail() {
		return _email;
	}
	
	public void setEmail(String email) {
		this._email = email;
	}
	
	public char getGender() {
		return _gender;
	}
	
	public String toString() {
		String txt = String.format("Author[Name = %s, Email = %s, Gender = %c ]", _name, _email, _gender) ;
		return txt; 
	}
	
}
