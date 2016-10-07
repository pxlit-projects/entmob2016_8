package be.pxl.spring;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.context.*;

import be.pxl.spring.config.*;
import be.pxl.spring.controller.UserRestController;
import be.pxl.spring.domain.User;
import be.pxl.spring.repository.UserRepository;
import be.pxl.spring.service.UserService;

/**
 * Hello world!
 *
 */
public class App {
	

	
	public static void main(String[] args) {
		ConfigurableApplicationContext ctx = SpringApplication.run(
				AppConfig.class, args);
		User u = new User();
		u.setFirstName("brecht");
		System.out.println(u.getFirstName());		
		UserService uService = new UserService();
		
		uService.save(u);

		System.out.println("TEST");
	}
}
