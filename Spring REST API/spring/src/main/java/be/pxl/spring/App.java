package be.pxl.spring;

import java.sql.Timestamp;
import java.util.Date;
import java.util.List;
import java.util.Set;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.ConfigurableApplicationContext;

import be.pxl.spring.controller.SessionRestController;
import be.pxl.spring.controller.UserRestController;
import be.pxl.spring.controller.UserSessionRestController;
import be.pxl.spring.domain.Session;
import be.pxl.spring.domain.User;
import be.pxl.spring.service.UserService;
import be.pxl.spring.service.UserServiceImpl;

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
		u.setSalt("test");
		u.setRole("test");
		System.out.println(u.getFirstName());		
		UserRestController urc = ctx.getBean(UserRestController.class);
		int newUserId = urc.updateUser(u);
		System.out.println("Nieuwe UserId: "+newUserId);
		User morrhey = urc.getUserById(1).getBody();
		System.out.println(morrhey.getLastName());
		System.out.println(urc.login(1, "test"));
		
		
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
			System.out.println(session.getUserId()+": "+session.getStartTime());
		}
		
		List<User> userList = urc.getUsersByName("brech");
		
		for (User user : userList) {
			System.out.println(user.getUserId()+": "+ user.getFirstName()+" "+user.getLastName());
		}
		
		sessionList = src.getSessionsByDate(ts);
		for (Session session : sessionList) {
			System.out.println("sessie by date: "+ session.getUserId());
		}
		
		User u1 = urc.getUserById(1).getBody();
		u1.setFirstName("Jasper");
		u1.setLastName("Szkudlarski ofzoiets");
		urc.updateUser(u1);

		double average = src.getAverageActualTime(sessionList.get(0).getStartTime(),
		sessionList.get(sessionList.size()-1).getEndTime());
		System.out.println("gemiddelde tijd: " + average);
		
		UserSessionRestController usrc = ctx.getBean(UserSessionRestController.class);		
		User u2 = usrc.getUserSessionById(1);
		s.setUserId(1);
		date = new Date();
		ts = new Timestamp(date.getTime());
		s.setActualTime(15);
		s.setStartTime(ts);
		s.setEndTime(ts);
		s.setUserId(1);		
		src.updateSession(s);
		u2.getSessions().add(s);
		urc.updateUser(u2);
		u2 = usrc.getUserSessionById(1);
		
		Set<Session> userSessions = u2.getSessions();
		for (Session session : userSessions) {
			System.out.println(session.getSessionId()+": " +session.getStartTime()+" - "+ session.getEndTime());
		}
		
		System.out.println("By Date: ");	
		User u3 = usrc.getUserSessionByDate(1, ts);
		userSessions = u3.getSessions();
		for (Session session : userSessions) {
			System.out.println(session.getSessionId()+": " +session.getStartTime()+" - "+ session.getEndTime());
		}
		
		System.out.println(src.getLastSession(1).getBody().getSessionId());
		System.out.println("TEST");
	}
}
