import java.util.Arrays;

public class Book {
	private String _name;
	private Author[] _authors; 
	private double _price;
	private int _qty = 0; 

	public Book(String name, Author[] authors, double price) {
		this._name = name;
		this._authors = authors;
		this._price = price;
	}

	public Book(String name, Author[] authors, double price, int qty) {
		this._name = name;
		this._authors = authors;
		this._price = price;
		this._qty = qty;
	}

	public String getName() {
		return _name;
	}

	public Author[] getAuthors() {
		return _authors;
	}

	public double getPrice() {
		return _price;
	}

	public int getQty() {
		return _qty;
	}

	public void setPrice(double price) {
		this._price = price;
	}

	public void setQty(int qty) {
		this._qty = qty;
	}

	@Override
	public String toString() {
		String authorsStr = Arrays.toString(_authors);
		return String.format("Book[name=%s, authors=%s, price=%.2f, qty=%d]", _name, authorsStr, _price, _qty);
	}
	
	public String getAuthorNames() {
		String names = "";
		for (int i = 0; i < _authors.length; i++) {
			names += _authors[i].getName();
			if (i < _authors.length - 1) {
				names += ", ";
			}
		}
		return names;
	}
}
