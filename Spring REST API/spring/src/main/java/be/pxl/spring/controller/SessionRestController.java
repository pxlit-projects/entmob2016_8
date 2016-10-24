package be.pxl.spring.controller;

import java.sql.Timestamp;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.RequestEntity;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import be.pxl.spring.domain.Session;
import be.pxl.spring.service.SessionService;

@RestController
@RequestMapping(value="/session", produces="application/json")
public class SessionRestController {

	@Autowired
	private SessionService sessionservice;
	
	@RequestMapping(method = RequestMethod.GET, value = "{id}")
	public Session getSessionById(@PathVariable("id") int id){		
		return sessionservice.findOne(id);
		
	}
	@RequestMapping(method = RequestMethod.POST)
	public int updateSession(@RequestBody Session s){
		sessionservice.save(s);
		sessionservice.flush();
		return s.getSessionId();
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByUserId/{userId}")
	public List<Session> getSessionsByUserId(@PathVariable("userId") int userId){
		return sessionservice.findByUserId(userId);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByDate/{timeStamp}")
	public List<Session> getSessionsByDate(@PathVariable("timeStamp") Timestamp timeStamp){
		return sessionservice.findByDate(timeStamp);
		
	}
	
	@RequestMapping(method = RequestMethod.GET, value = "ByGreaterStart/{timeStamp}")
	public List<Session> getSessionsByGreaterStartTime(@PathVariable("timeStamp") Timestamp timeStamp){
		return sessionservice.findByGreaterStartTime(timeStamp);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByLesserEnd/{timeStamp}")
	public List<Session> getSessionsByLesserEndTime(@PathVariable("timeStamp") Timestamp timeStamp){
		return sessionservice.findByLesserEndTime(timeStamp);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByGreaterActual/{time}")
	public List<Session> getSessionsByGreaterActualTime(@PathVariable("time") int time){
		return sessionservice.findByGreaterActualTime(time);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "ByLesserActual/{time}")
	public List<Session> getSessionsByLesserActualTime(@PathVariable("time") int time){
		return sessionservice.findByLesserActualTime(time);
		
	}
	@RequestMapping(method = RequestMethod.GET, value = "Between/{startTime}/{endTime}")
	public List<Session> getSessionsBetween(@PathVariable("startTime") Timestamp startTime,
			@PathVariable("endTime") Timestamp endTime ){
		
		return sessionservice.findBetween(startTime, endTime);
		
	}
	@RequestMapping(method = RequestMethod.DELETE)
	public void deleteSession(@RequestBody Session s){
		sessionservice.delete(s);
	}
	@RequestMapping(method = RequestMethod.GET, value="AverageActualTime/{startTime}/{endTime}")
	public double getAverageActualTime(@PathVariable("startTime") Timestamp startTime,
			@PathVariable("endTime") Timestamp endTime ){
		
				return sessionservice.getAverageActualTime(startTime, endTime);
		
	}
	
	@RequestMapping(method = RequestMethod.GET, value="LastSession/{id}")
	public ResponseEntity<Session> getLastSession(@PathVariable("id") int userId){
		Session s = sessionservice.getLastSession(userId);
		HttpStatus status = HttpStatus.OK;
		if(s == null){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<Session>(s, status);
	}
	@RequestMapping(method = RequestMethod.GET, value="FirstSession/{id}")
	public ResponseEntity<Session> getFirstSession(@PathVariable("id") int userId){
		Session s = sessionservice.getFirstSession(userId);
		HttpStatus status = HttpStatus.OK;
		if(s == null){
			status = HttpStatus.NOT_FOUND;
		}
		return new ResponseEntity<Session>(s, status);
	}
}
