class Something
end

class Example
  attr_accessor :basic_price
  attr_accessor :tax_free
  attr_accessor :age

  def calculate_sum(array)
    sum = 0
    array.each do |i|
      sum += i
    end

    sum
  end

  def tax
  	price * 0.08
  end

  def payment
  	if tax_free
  		price
  	else
  		price + tax
  	end
  end

  def price
  	case age
  	when 0..10
      basic_price * 0.3
    when 11..19
      basic_price * 0.8
    when 20
      basic_price * 0.1
    else
      basic_price
    end
  end

  def cal
  	num = 1
  	result = 1
  	while true
      result *= num
      break num if 1000000 < result
      num += 1
  	end
  end

  def output
  	puts calculate_sum [1,3,5]

  	self.basic_price = 1000
  	self.age = 20
  	puts price

  	puts tax

    puts payment
    puts cal
  end
end

one ||= Something.new
  
Example.new.output