package be.pxl.spring;

import org.junit.*;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ThreadLocalRandom;










import be.pxl.spring.domain.Session;
import be.pxl.spring.service.SessionUtility;

@RunWith(SpringJUnit4ClassRunner.class)
@DirtiesContext
@ContextConfiguration(classes=TestConfig.class)
public class SessionUtilityTest {
	@Autowired
	SessionUtility su;
//	@Before
//	public void before(){
//		su = new SessionUtility();
//	}
	
	@Test
	public void testAverage(){
		int actualTime, sum, count;
		Session s;
		List<Session> sessionList = new ArrayList<Session>();
		count = 10;
		sum=0;
		
		for(int i = 0; i<count; i++){
		s = new Session();
		actualTime= ThreadLocalRandom.current().nextInt(1000);
		s.setActualTime(actualTime);
		sessionList.add(s);
		sum+= actualTime;		
		}
		Assert.assertEquals(((double)sum)/count, su.AverageActual(sessionList), 0);
	}
	@Test
	public void testMinimal(){
		int actualTime, min, count;
		Session s;
		List<Session> sessionList = new ArrayList<Session>();
		count = 10;
		min=Integer.MAX_VALUE;
		
		for(int i = 0; i<count; i++){
		s = new Session();
		actualTime= ThreadLocalRandom.current().nextInt(1000);
		s.setActualTime(actualTime);
		sessionList.add(s);
		min = actualTime < min ? actualTime : min;		
		}
		Assert.assertEquals(min, su.MinimalActual(sessionList));
	}
	@Test
	public void testMaximal(){
		int actualTime, max, count;
		Session s;
		List<Session> sessionList = new ArrayList<Session>();
		count = 10;
		max=Integer.MIN_VALUE;
		
		for(int i = 0; i<count; i++){
		s = new Session();
		actualTime= ThreadLocalRandom.current().nextInt(1000);
		s.setActualTime(actualTime);
		sessionList.add(s);
		max = actualTime > max ? actualTime : max;		
		}
		Assert.assertEquals(max, su.MaximalActual(sessionList));
	}

}
