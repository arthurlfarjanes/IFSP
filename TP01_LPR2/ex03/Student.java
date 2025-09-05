package ex03;

public class Student extends Person {
	private String _program;
	private int _year;
	private double _fee;
	
	public Student(String name, String adress, String program, int year, double fee) {
		super(name, adress);
		this._program = program;
		this._year = year;
		this._fee = fee;
	}
	public String getProgram() {
		return _program;
	}
	public void setProgram(String program) {
		this._program = program;
	}
	public int getYear() {
		return _year;
	}
	public void setYear(int year) {
		this._year = year;
	}
	public double getFee() {
		return _fee;
	}
	public void setFee(double fee) {
		this._fee = fee;
	}
	@Override
	public String toString() {
		String txt = String.format("Student[%s, program = %s, year = %d, fee = %.2f]", super.toString(), _program, _year, _fee);
		return txt; 
	}
	
}
