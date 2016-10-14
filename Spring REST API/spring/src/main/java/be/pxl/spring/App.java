package be.pxl.spring;

import java.sql.Timestamp;
import java.util.Date;
import java.util.List;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;

import be.pxl.spring.controller.SessionRestController;
import be.pxl.spring.controller.UserRestController;
import be.pxl.spring.domain.Session;
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
		u.setDepartment("test");
		u.setLastName("morrhey");
		u.setPassword("test");		
		System.out.println(u.getFirstName());		
		UserRestController urc = ctx.getBean(UserRestController.class);
		urc.updateUser(u);
		User morrhey = urc.getUserById(1);
		System.out.println(morrhey.getLastName());
		
		Session s = ctx.getBean(Session.class);
		s.setUserId(1);
		java.util.Date date = new Date();
		Timestamp ts = new Timestamp(date.getTime());
		s.setActualTime(10);
		s.setStartTime(ts);
		s.setEndTime(ts);
		s.setUserId(1);
		SessionRestController src = ctx.getBean(SessionRestController.class);
		src.updateSession(s);
		
		List<Session> sessionList = src.getSessionsByUserId(1);
		
		for (Session session : sessionList) {
			System.out.println(session.getStartTime());
		}
		
		List<User> userList = urc.getUsersByName("brech");
		
		for (User user : userList) {
			System.out.println(user.getFirstName()+" "+user.getLastName());
		}
		

		System.out.println("TEST");
	}
}
