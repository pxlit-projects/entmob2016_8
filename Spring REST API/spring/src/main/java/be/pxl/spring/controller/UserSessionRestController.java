package be.pxl.spring.controller;

import java.sql.Timestamp;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.spring.domain.Session;
import be.pxl.spring.domain.User;
import be.pxl.spring.service.UserService;

@RestController
@RequestMapping(value="/usersession", produces="application/json")
public class UserSessionRestController {

	@Autowired
	UserService us;
	
	@RequestMapping(method = RequestMethod.GET, value="{id}")
	public User getUserSessionById(@PathVariable("id") int id){
		return us.findById(id);
	}	
	@RequestMapping(method = RequestMethod.GET, value = "ByDate/{id}/{timeStamp}")
	public User getUserSessionByDate(@PathVariable("id")int id, @PathVariable("timeStamp") Timestamp timeStamp){
		return us.findByDate(id, timeStamp);
		
	}
	
	@RequestMapping(method = RequestMethod.GET, value = "ByGreaterStart/{id}/{timeStamp}")
	public User getUserSessionByGreaterStartTime(@PathVariable("id")int id, @PathVariable("timeStamp") Timestamp timeStamp){
		return us.findByGreaterStartTime(id, timeStamp);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByLesserEnd/{id}/{timeStamp}")
	public User getUserSessionByLesserEndTime(@PathVariable("id") int id, @PathVariable("timeStamp") Timestamp timeStamp){
		return us.findByLesserEndTime(id, timeStamp);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByGreaterActual/{id}/{time}")
	public User getUserSessionByGreaterActualTime(@PathVariable("id") int id, @PathVariable("time") int time){
		return us.findByGreaterActualTime(id, time);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByLesserActual/{id}/{time}")
	public User getUserSessionByLesserActualTime(@PathVariable("id") int id, @PathVariable("time") int time){
		return us.findByLesserActualTime(id, time);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "Between/{id}/{startTime}/{endTime}")
	public User getUserSessionBetween(@PathVariable("id") int id, @PathVariable("startTime") Timestamp startTime,
			@PathVariable("endTime") Timestamp endTime ){
		
		return us.findBetween(id, startTime, endTime);
		
	}
	
	@RequestMapping(method = RequestMethod.GET, value="AverageActualTime/{id}/{startTime}/{endTime}")
	public double getAverageActualTime(@PathVariable("id") int id, @PathVariable("startTime") Timestamp startTime,
			@PathVariable("endTime") Timestamp endTime ){
		
				return us.getAverageActualTime(id, startTime, endTime);
		
	}
	@RequestMapping(method = RequestMethod.GET, value="AverageActualTime/{id}")
	public double getAverageActualTime(@PathVariable("id") int id){
		
				return us.getAverageActualTime(id);
		
	}
	@RequestMapping(method = RequestMethod.GET, value="MinimalActualTime/{id}")
	public int getMinimalActualTime(@PathVariable("id") int id){
		return us.getMinimalActualTime(id);
	}
	@RequestMapping(method = RequestMethod.GET, value="MinimalActualTime/{id}/{startTime}/{endTime}")
	public int getMinimalActualTime(@PathVariable("id") int id, @PathVariable("startTime") Timestamp startTime,
			@PathVariable("endTime") Timestamp endTime ){
		return us.getMinimalActualTime(id, startTime, endTime);
	}
	@RequestMapping(method = RequestMethod.GET, value="MaximalActualTime/{id}")
	public int getMaximalActualTime(@PathVariable("id") int id){
		return us.getMaximalActualTime(id);
	}
	@RequestMapping(method = RequestMethod.GET, value="MaximalActualTime/{id}/{startTime}/{endTime}")
	public int getMaximalActualTime(@PathVariable("id") int id, @PathVariable("startTime") Timestamp startTime,
			@PathVariable("endTime") Timestamp endTime ){
		return us.getMaximalActualTime(id, startTime, endTime);
	}
}
