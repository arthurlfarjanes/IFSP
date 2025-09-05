package ex03;

public class Staff extends Person{
	private String _school;
	private double _pay;
	
	public Staff(String name, String adress, String school, double pay) {
		super(name, adress);
		this._school = school;
		this._pay = pay;
	}
	public String getSchool() {
		return _school;
	}
	public void setSchool(String school) {
		this._school = school;
	}
	public Double getPay() {
		return _pay;
	}
	public void setPay(double pay) {
		this._pay = pay;
	}
	@Override
	public String toString() {
		String txt = String.format("Staff[%s, School = %s, pay = %.2f]", super.toString(), _school, _pay);
		return txt; 
	}
}
