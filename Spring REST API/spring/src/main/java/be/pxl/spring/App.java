package be.pxl.spring;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;

import be.pxl.spring.controller.UserRestController;
import be.pxl.spring.domain.User;

/**
 * Hello world!
 *
 */
@SpringBootApplication
public class App {
	

	
	public static void main(String[] args) {
		ConfigurableApplicationContext ctx = SpringApplication.run(
				App.class, args);
		User u = ctx.getBean(User.class);
		u.setFirstName("brecht");
		System.out.println(u.getFirstName());		
		UserRestController urc = new UserRestController();
		urc.updateUser(u);

		System.out.println("TEST");
	}
}
