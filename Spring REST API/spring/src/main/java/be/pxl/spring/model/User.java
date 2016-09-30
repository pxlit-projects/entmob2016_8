package be.pxl.spring.model;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

@Component
@Scope("prototype")
public class User {
	
	int userId;
	String firstName, lastName, password, department;

}
